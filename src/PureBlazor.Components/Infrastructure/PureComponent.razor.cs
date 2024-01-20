using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace PureBlazor.Components.Infrastructure;

public partial class PureComponent
{
    [Inject]
    protected ILogger<PureComponent> Log { get; set; }
}