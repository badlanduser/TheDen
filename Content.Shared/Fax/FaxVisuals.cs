// SPDX-FileCopyrightText: 2022 Morb <14136326+Morb0@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 sleepyyapril <123355664+sleepyyapril@users.noreply.github.com>
//
// SPDX-License-Identifier: MIT

using Robust.Shared.Serialization;

namespace Content.Shared.Fax;

[Serializable, NetSerializable]
public enum FaxMachineVisuals : byte
{
    VisualState,
}

[Serializable, NetSerializable]
public enum FaxMachineVisualState : byte
{
    Normal,
    Inserting,
    Printing
}
