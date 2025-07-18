// SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 sleepyyapril <123355664+sleepyyapril@users.noreply.github.com>
//
// SPDX-License-Identifier: MIT

using Robust.Shared.Serialization;

namespace Content.Shared.Mind;

[Serializable, NetSerializable]
public enum ToggleableGhostRoleVisuals : byte
{
    Status
}

[Serializable, NetSerializable]
public enum ToggleableGhostRoleStatus : byte
{
    Off,
    Searching,
    On
}
