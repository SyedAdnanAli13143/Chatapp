using System;
using System.Collections.Generic;

namespace SignalR.EFModels;

public partial class Connections
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public string SignalrId { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public virtual Person Person { get; set; } = null!;
}
