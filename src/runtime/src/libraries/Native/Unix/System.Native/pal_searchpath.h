// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#pragma once

#include "pal_compiler.h"
#include "pal_types.h"

PALEXPORT const char* SystemNative_SearchPath(int32_t folderId);

PALEXPORT const char* SystemNative_SearchPath_TempDirectory(void);
