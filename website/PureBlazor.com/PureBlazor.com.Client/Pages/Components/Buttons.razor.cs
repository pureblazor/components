using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Buttons;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Primitives;

namespace PureBlazor.com.Client.Pages.Components;

public partial class Buttons
{
    const string s = """"
                     <PureButton Accent="Success" Accent="Brand">Success</PureButton>
                     """";

    const string s2 = """"
                      <PureButton Variant="PureVariant.Outline" Accent="Brand">Primary</PureButton>
                      """";

    private const string s3 = """"
                              <PureButton Variant="PureVariant.Subtle" Accent="Brand">Primary</PureButton>
                              """";

    private const string s4 = """"
                              <CascadingValue Value="demoTheme">
                                  <PureButton Accent="Brand">Brand</PureButton>
                                  <PureButton Accent="Success">Success</PureButton>
                                  <PureButton Accent="Warning">Warning</PureButton>
                                  <PureButton Accent="Danger">Danger</PureButton>
                                  <PureButton Accent="Accent.Default">Default</PureButton>
                              </CascadingValue>
                              @code {
                                  private readonly DefaultTheme theme = new();
                                  private PureTheme demoTheme;

                                  public Buttons()
                                  {
                                      var customizedVariants = new Dictionary<PureVariant, Dictionary<Accent, string>>
                                      {
                                          {
                                              PureVariant.Default,
                                              new Dictionary<Accent, string>
                                              {
                                                  {
                                                      Accent.Brand,
                                                      "bg-gradient-to-r from-indigo-500 via-purple-500 to-pink-500 hover:bg-gradient-to-l"
                                                  },
                                                  { Accent.Success, "bg-gradient-to-r from-brand-300 to-emerald-500 hover:bg-gradient-to-l" },
                                                  {
                                                      Accent.Danger,
                                                      "bg-gradient-to-r from-orange-300 from-10% via-red-700 via-50% to-90% to-orange-700 hover:bg-gradient-to-l"
                                                  },
                                                  {
                                                      Accent.Default,
                                                      "bg-gradient-to-r from-green-400 to-blue-500 hover:from-pink-500 hover:to-yellow-500"
                                                  }
                                              }
                                          }
                                      };

                                      var customizedStyles = new Dictionary<string, ComponentStyle>
                                      {
                                          {
                                              nameof(PureButton),
                                              new ComponentStyle(theme.Styles[nameof(PureButton)].Base, null, customizedVariants,
                                                  theme.Styles[nameof(PureButton)].Sizes)
                                          }
                                      };

                                      theme.Merge(customizedStyles);

                                      demoTheme = theme with { Styles = customizedStyles };
                                  }
                              }
                              """";

    private const string s5 = """"
                              <CascadingValue Value="Theme.Off">
                                  <PureButton Styles="bg-sky-400 text-gray-50 text-3xl p-3 cursor-pointer">Custom button 1</PureButton>
                                  <PureButton Styles="bg-emerald-400 text-gray-50 text-3xl p-3 cursor-pointer">Custom button 2</PureButton>
                              </CascadingValue>
                              """";

    private const string s6 = """"
                              <PureButton Accent="Danger" LeftIcon="PureIcons.IconBeaker">Experiment</PureButton>
                              """";

    private const string s7 = """"
                              <PureButton OnClick="() => clickCount2++">Click me</PureButton>
                              <PureButton Accent="Success" OnClick="() => clickCount2++" Disabled="true">Can't click me now</PureButton>
                              <PureButton Accent="Warning" OnClick="() => clickCount2++" Loading="true">Waiting for something</PureButton>
                              """";

    private readonly DefaultTheme theme = new();
    private PureTheme demoTheme;

    public Buttons()
    {
        var customizedVariants = new Dictionary<PureVariant, Dictionary<Accent, string>>
        {
            {
                PureVariant.Default,
                new Dictionary<Accent, string>
                {
                    {
                        Accent.Brand,
                        "bg-gradient-to-r from-indigo-500 via-purple-500 to-pink-500 hover:bg-gradient-to-l"
                    },
                    { Accent.Success, "bg-gradient-to-r from-brand-300 to-emerald-500 hover:bg-gradient-to-l" },
                    {
                        Accent.Danger,
                        "bg-gradient-to-r from-orange-300 from-10% via-red-700 via-50% to-90% to-orange-700 hover:bg-gradient-to-l"
                    },
                    {
                        Accent.Default,
                        "bg-gradient-to-r from-green-400 to-blue-500 hover:from-pink-500 hover:to-yellow-500"
                    }
                }
            }
        };

        var customizedStyles = new Dictionary<string, ComponentStyle>
        {
            {
                nameof(PureButton),
                new ComponentStyle(theme.Styles[nameof(PureButton)].Base)
                {
                    Variants = customizedVariants, Sizes = theme.Styles[nameof(PureButton)].Sizes
                }
            }
        };

        // theme.Merge(customizedStyles);

        demoTheme = theme with { Styles = customizedStyles };
    }
}
