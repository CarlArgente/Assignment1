﻿using System;
using System.Collections.Generic;

namespace Assignment1.DataContextModels;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Address { get; set; }
}
