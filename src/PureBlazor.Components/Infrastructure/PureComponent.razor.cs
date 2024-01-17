using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace PureBlazor.Components;

public partial class PureComponent
{
    [Inject]
    protected ILogger<PureComponent> Log { get; set; }
}