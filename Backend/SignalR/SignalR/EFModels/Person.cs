using System;
using System.Collections.Generic;

namespace SignalR.EFModels;

public partial class Person
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Connections> Connections { get; set; } = new List<Connections>();
}
