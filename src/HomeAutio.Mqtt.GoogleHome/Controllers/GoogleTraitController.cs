﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HomeAutio.Mqtt.GoogleHome.ActionFilters;
using HomeAutio.Mqtt.GoogleHome.Models;
using HomeAutio.Mqtt.GoogleHome.Models.State;
using HomeAutio.Mqtt.GoogleHome.Models.State.Challenges;
using HomeAutio.Mqtt.GoogleHome.Validation;
using HomeAutio.Mqtt.GoogleHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HomeAutio.Mqtt.GoogleHome.Controllers
{
    /// <summary>
    /// Traits controller.
    /// </summary>
    [Authorize]
    public class GoogleTraitController : Controller
    {
        private readonly IGoogleDeviceRepository _deviceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleTraitController"/> class.
        /// </summary>
        /// <param name="deviceRepository">Device repository.</param>
        public GoogleTraitController(IGoogleDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository ?? throw new ArgumentException(nameof(deviceRepository));
        }

        /// <summary>
        /// Edit device.
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <returns>Response.</returns>
        [ImportModelState]
        public IActionResult Create([Required] string deviceId)
        {
            if (!_deviceRepository.Contains(deviceId))
                return NotFound();

            var device = _deviceRepository.Get(deviceId);
            ViewBag.SupportedTraits = DeviceMetadata.SupportedTraits.TryGetValue(device.Type, out IList<TraitType> supportedDevices)
                ? supportedDevices.Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() })
                : Enumerable.Empty<SelectListItem>();

            var model = new TraitViewModel();

            return View(model);
        }

        /// <summary>
        /// Edit trait.
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <param name="viewModel">View Model.</param>
        /// <returns>Response.</returns>
        [HttpPost]
        [ExportModelState]
        public IActionResult Create([Required] string deviceId, TraitViewModel viewModel)
        {
            if (!_deviceRepository.Contains(deviceId))
                return NotFound();

            var device = _deviceRepository.GetDetached(deviceId);
            if (device.Traits.Any(x => x.Trait == viewModel.Trait))
                ModelState.AddModelError("Trait", "Device already contains trait");

            if (DeviceMetadata.SupportedTraits.TryGetValue(device.Type, out IList<TraitType> supportedTraits) && !supportedTraits.Contains(viewModel.Trait))
                ModelState.AddModelError("Trait", "Device does not support trait type");

            // Set values
            var trait = new DeviceTrait
            {
                Trait = viewModel.Trait,
                Attributes = !string.IsNullOrEmpty(viewModel.Attributes) ? JsonConvert.DeserializeObject<Dictionary<string, object>>(viewModel.Attributes, new ObjectDictionaryConverter()) : null,
                Commands = !string.IsNullOrEmpty(viewModel.Commands) ? JsonConvert.DeserializeObject<Dictionary<string, IDictionary<string, string>>>(viewModel.Commands) : null,
                State = !string.IsNullOrEmpty(viewModel.State) ? JsonConvert.DeserializeObject<Dictionary<string, DeviceState>>(viewModel.State) : null
            };

            // Handle any challenges
            switch (viewModel.ChallengeType)
            {
                case ChallengeType.Acknowledge:
                    trait.Challenge = new AcknowledgeChallenge();
                    break;
                case ChallengeType.Pin:
                    trait.Challenge = new PinChallenge
                    {
                        Pin = viewModel.ChallengePin
                    };
                    break;
                case ChallengeType.None:
                default:
                    trait.Challenge = null;
                    break;
            }

            // Final validation
            foreach (var error in DeviceTraitValidator.Validate(trait))
                ModelState.AddModelError(string.Empty, error);

            if (!ModelState.IsValid)
                return RedirectToAction("Create", new { deviceId });

            // Save changes
            device.Traits.Add(trait);
            _deviceRepository.Update(deviceId, device);

            return RedirectToAction("Edit", "GoogleDevice", new { deviceId });
        }

        /// <summary>
        /// Delete device.
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <param name="traitId">Trait id.</param>
        /// <returns>Response.</returns>
        [HttpPost]
        public IActionResult Delete([Required] string deviceId, [Required] string traitId)
        {
            if (!_deviceRepository.Contains(deviceId))
                return NotFound();

            var device = _deviceRepository.GetDetached(deviceId);

            var traitEnumId = traitId.ToEnum<TraitType>();
            if (!device.Traits.Any(x => x.Trait == traitEnumId))
                return NotFound();

            // Save changes
            device.Traits.Remove(device.Traits.First(x => x.Trait == traitEnumId));
            _deviceRepository.Update(deviceId, device);

            return RedirectToAction("Edit", "GoogleDevice", new { deviceId });
        }

        /// <summary>
        /// Edit device.
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <param name="traitId">Trait id.</param>
        /// <returns>Response.</returns>
        [ImportModelState]
        public IActionResult Edit([Required] string deviceId, [Required] string traitId)
        {
            if (!_deviceRepository.Contains(deviceId))
                return NotFound();

            var device = _deviceRepository.Get(deviceId);

            var traitEnumId = traitId.ToEnum<TraitType>();
            if (!device.Traits.Any(x => x.Trait == traitEnumId))
                return NotFound();

            ViewBag.SupportedTraits = DeviceMetadata.SupportedTraits.TryGetValue(device.Type, out IList<TraitType> supportedDevices)
                ? supportedDevices.Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString(), Selected = traitEnumId == x })
                : Enumerable.Empty<SelectListItem>();

            // Get trait
            var trait = device.Traits.First(x => x.Trait == traitEnumId);
            var model = new TraitViewModel
            {
                Trait = trait.Trait,
                Attributes = trait.Attributes != null ? JsonConvert.SerializeObject(trait.Attributes, Formatting.Indented) : null,
                Commands = trait.Commands != null ? JsonConvert.SerializeObject(trait.Commands, Formatting.Indented) : null,
                State = trait.State != null ? JsonConvert.SerializeObject(trait.State, Formatting.Indented) : null
            };

            // Handle any challenges
            switch (trait.Challenge)
            {
                case AcknowledgeChallenge ackChallenge:
                    model.ChallengeType = ChallengeType.Acknowledge;
                    break;
                case PinChallenge pinChallenge:
                    model.ChallengeType = ChallengeType.Pin;
                    model.ChallengePin = pinChallenge.Pin;
                    break;
                default:
                    model.ChallengeType = ChallengeType.None;
                    break;
            }

            return View(model);
        }

        /// <summary>
        /// Edit trait.
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <param name="traitId">Trait id.</param>
        /// <param name="viewModel">View Model.</param>
        /// <returns>Response.</returns>
        [HttpPost]
        [ExportModelState]
        public IActionResult Edit([Required] string deviceId, [Required] string traitId, TraitViewModel viewModel)
        {
            if (!_deviceRepository.Contains(deviceId))
                return NotFound();

            var device = _deviceRepository.GetDetached(deviceId);

            var traitEnumId = traitId.ToEnum<TraitType>();
            if (!device.Traits.Any(x => x.Trait == traitEnumId))
                return NotFound();

            // Lock the trait type just in case
            viewModel.Trait = traitEnumId;

            if (DeviceMetadata.SupportedTraits.TryGetValue(device.Type, out IList<TraitType> supportedTraits) && !supportedTraits.Contains(viewModel.Trait))
                ModelState.AddModelError("Trait", "Device does not support trait type");

            // Set new values
            var trait = device.Traits.FirstOrDefault(x => x.Trait == traitEnumId);
            trait.Attributes = !string.IsNullOrEmpty(viewModel.Attributes) ? JsonConvert.DeserializeObject<Dictionary<string, object>>(viewModel.Attributes, new ObjectDictionaryConverter()) : null;
            trait.Commands = !string.IsNullOrEmpty(viewModel.Commands) ? JsonConvert.DeserializeObject<Dictionary<string, IDictionary<string, string>>>(viewModel.Commands) : null;
            trait.State = !string.IsNullOrEmpty(viewModel.State) ? JsonConvert.DeserializeObject<Dictionary<string, DeviceState>>(viewModel.State) : null;

            // Handle any challenges
            switch (viewModel.ChallengeType)
            {
                case ChallengeType.Acknowledge:
                    trait.Challenge = new AcknowledgeChallenge();
                    break;
                case ChallengeType.Pin:
                    trait.Challenge = new PinChallenge
                    {
                        Pin = viewModel.ChallengePin
                    };
                    break;
                case ChallengeType.None:
                default:
                    trait.Challenge = null;
                    break;
            }

            // Final validation
            foreach (var error in DeviceTraitValidator.Validate(trait))
                ModelState.AddModelError(string.Empty, error);

            if (!ModelState.IsValid)
                return RedirectToAction("Edit", new { deviceId, traitId });

            // Save changes
            _deviceRepository.Update(deviceId, device);

            return RedirectToAction("Edit", "GoogleDevice", new { deviceId });
        }
    }
}
