﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities;

public class EmailAuthenticator: Entity<Guid>
{
    public Guid UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; } = null!;

    public EmailAuthenticator()
    {
        
    }

    public EmailAuthenticator(Guid userId, bool ısVerified)
    {
        UserId = userId;
        IsVerified = ısVerified;
    }

    public EmailAuthenticator(Guid id, Guid userId, bool ısVerified): base(id)
    {
        UserId = userId;
        IsVerified = ısVerified;
    }
}
