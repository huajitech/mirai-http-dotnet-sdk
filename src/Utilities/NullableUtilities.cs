﻿namespace HuajiTech.Mirai.Http.Utilities
{
    internal static class NullableUtilities
    {
        public static bool NullEquals(object left, object right) => left is null && right is null;
    }
}