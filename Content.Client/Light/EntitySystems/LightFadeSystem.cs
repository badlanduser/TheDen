// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Skubman <ba.fallaria@gmail.com>
// SPDX-FileCopyrightText: 2025 sleepyyapril <123355664+sleepyyapril@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later AND MIT

using Content.Client.Light.Components;
using Robust.Client.Animations;
using Robust.Client.GameObjects;
using Robust.Shared.Animations;

namespace Content.Client.Light.EntitySystems;

public sealed class LightFadeSystem : EntitySystem
{
    [Dependency] private readonly AnimationPlayerSystem _player = default!;

    private const string FadeTrack = "light-fade";

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<LightFadeComponent, ComponentStartup>(OnFadeStartup);
    }

    private void OnFadeStartup(EntityUid uid, LightFadeComponent component, ComponentStartup args)
    {
        if (!TryComp<PointLightComponent>(uid, out var light))
            return;

        var animation = new Animation()
        {
            Length = TimeSpan.FromSeconds(component.Duration),
            AnimationTracks =
            {
                new AnimationTrackComponentProperty()
                {
                    Property = nameof(PointLightComponent.Energy),
                    ComponentType = typeof(PointLightComponent),
                    InterpolationMode = AnimationInterpolationMode.Cubic,
                    KeyFrames =
                    {
                        new AnimationTrackProperty.KeyFrame(0f, 0f),
                        new AnimationTrackProperty.KeyFrame(light.Energy, component.RampUpDuration),
                        new AnimationTrackProperty.KeyFrame(0f, component.Duration)
                    }
                }
            }
        };

        _player.Play(uid, animation, FadeTrack);
    }
}
