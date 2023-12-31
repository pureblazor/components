using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace PureBlazor.Components;

public partial class MkComponent
{
    [Inject]
    protected ILogger<MkComponent> Log { get; set; }
}
