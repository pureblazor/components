namespace PureBlazor.com.Client.Pages.Components;

public static class Samples
{
    public const string AlertServiceUsage = """
                                            <PureButton OnClick="() => AddAlert(Success)">Success</PureButton>
                                            <PureAlertProvider />
                                            @code {
                                                [Inject]
                                                public AlertService Service { get; set; }
                                                public async Task AddAlert(Accent state)
                                                {
                                                    await Service.ShowAsync("Adding your alert...", state);
                                                }
                                            }
                                            """;

    public const string DropdownStaticUsage = """
                                              <PureDropdown Items="Items" OnItemSelected="ItemSelected">
                                                  <ChildContent>Settings</ChildContent>
                                                  <MenuItems>
                                                      <PureDropdownItem OnItemSelected="() => ItemSelected(1)">One</PureDropdownItem>
                                                      <PureDropdownItem OnItemSelected="() => ItemSelected(2)">Two</PureDropdownItem>
                                                  </MenuItems>
                                              </PureDropdown>
                                              """;

    public const string DropdownDynamicUsage = """
                        <PureDropdown Items="Items" OnItemSelected="ItemSelected">
                            <ChildContent>Settings</ChildContent>
                            <MenuItems>
                                @foreach (var item in Items)
                                {
                                    <PureDropdownItem OnItemSelected="() => ItemSelected(item)">@item.Text</PureDropdownItem>
                                }
                            </MenuItems>
                        </PureDropdown>
                        """;

    public const string DialogBasicSample = """
                                            <PureButton OnClick="ShowConfirmDialog">Show Dialog</PureButton>
                                            <PureDialog/>
                                            @code {
                                                [Inject] public required DialogService DialogService { get; set; }
                                                public async Task ShowConfirmDialog()
                                                {
                                                    await DialogService.ShowDialog("Dialog title.", builder => builder.AddContent(0, "This is a dialog!"));
                                                }
                                            }
                                            """;

    public const string DialogAdvancedSample = """
                                            <PureButton OnClick="ShowConfirmDialog">Show Dialog</PureButton>
                                            <PureDialog/>
                                            @code {
                                                [Inject] public required DialogService DialogService { get; set; }
                                                public async Task ShowConfirmDialog()
                                                {
                                                    await DialogService.ShowDialog("Confirm", builder => builder.AddContent(0, "Watch out for gators!"),
                                                    new ShowDialogOptions
                                                    {
                                                        AckColor = Warning, AckButton = "I understand"
                                                    });
                                                }
                                            }
                                            """;

    public const string DialogInterrupt = """
                                          public async Task ShowValidatingDialog()
                                          {
                                              await DialogService.ShowDialog("Action Dialog", builder => builder.AddContent(0, "Press continue to simulate a 4 second network request."),
                                                  new ShowDialogOptions
                                                  {
                                                      OnConfirm = OnConfirmValidateEvent
                                                  });
                                          }

                                          private async Task<DialogEventResult> OnConfirmValidateEvent(DialogResult arg)
                                          {
                                              // Simulate a network request
                                              await Task.Delay(4000);

                                              // Return a dialog result that will keep the dialog open
                                              // To close the dialog, just return a Confirmed result:
                                              // `return DialogEventResult.Confirmed;`
                                              return new DialogEventResult
                                              {
                                                  // Signal the dialog to stay open
                                                  Interrupted = true,

                                                  // Show a continuation dialog
                                                  Message = "Validation failed",

                                                  // You can also pass a RenderFragment
                                                  //MessageFragment = MyRenderFragment
                                              };
                                          }
                                          """;

    public const string DialogContinuations = """
                                              public async Task ShowDialog()
                                              {
                                                  await DialogService.ShowDialog("Dialog title.", builder => builder.AddContent(0, "This is a dialog!"),
                                                      new ShowDialogOptions
                                                      {
                                                          OnConfirm = OnConfirmEvent
                                                      });
                                              }

                                              private async Task<DialogEventResult> OnConfirmEvent(DialogResult arg)
                                              {
                                                  return new DialogEventResult
                                                  {
                                                      // Signal the dialog to stay open
                                                      Interrupted = true,

                                                      // Show a continuation dialog
                                                      ContinueWith = new DialogInstance("component")
                                                      {
                                                          // Provide a RenderFragment for the 2nd dialog
                                                          Body = b => b.AddContent(0, "This is a continuation!"),
                                                      }
                                                  };
                                              }
                                              """;

    public const string FlyoutBasic = """
                                      <PureFlyout Title="New entity" IsOpen="ShowFlyout">
                                          This is a flyout.
                                      </PureFlyout>

                                      @code {
                                          public bool ShowFlyout { get; set; }

                                          public void OpenFlyout()
                                          {
                                              ShowFlyout = true;
                                          }
                                      }
                                      """;
}
