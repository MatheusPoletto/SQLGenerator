﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Models.Enums
{
    public enum InstructionType
    {
        SELECT,
        SUBSELECT,
        DISTINCT,
        TOP,
        ALL,
        COLUMN,
        FROM
    }
}
