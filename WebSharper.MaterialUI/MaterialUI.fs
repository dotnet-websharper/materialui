namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript
open WebSharper.React

[<Stub>]
type Styles private () =
    [<Name "classes">]
    member val Classes = X<Object<string>>

[<Stub>]
type PaletteIntention [<Inline "{}">] () =
    [<Name "main">]
    member val Main = X<string> with get, set
    [<Name "light">]
    member val Light = X<string> with get, set
    [<Name "dark">]
    member val Dark = X<string> with get, set
    [<Name "contrastText">]
    member val ContrastText = X<string> with get, set

type ThemeType =
    | [<Constant "light">] Light
    | [<Constant "dark">] Dark

[<Stub>]
type Palette [<Inline "{}">] () =
    [<Name "type">]
    member val Type = X<ThemeType> with get, set
    [<Name "primary">]
    member val Primary = X<PaletteIntention> with get, set
    [<Name "secondary">]
    member val Secondary = X<PaletteIntention> with get, set
    [<Name "error">]
    member val Error = X<PaletteIntention> with get, set
    [<Name "contrastThreshold">]
    member val ContrastThreshold = X<int> with get, set
    [<Name "tonalOffset">]
    member val TonalOffset = X<float> with get, set

[<Stub>]
type Theme [<Inline "{}">] () =
    [<Name "palette">]
    member val Palette = X<Palette> with get, set
    // todo: typography
    // todo: overrides
    // todo: props

[<Stub>]
type Colors private () =
    [<Name "amber">]
    member val Amber = X<PaletteIntention>
    [<Name "blue">]
    member val Blue = X<PaletteIntention>
    [<Name "blueGrey">]
    member val BlueGrey = X<PaletteIntention>
    [<Name "brown">]
    member val Brown = X<PaletteIntention>
    [<Name "common">]
    member val Common = X<PaletteIntention>
    [<Name "cyan">]
    member val Cyan = X<PaletteIntention>
    [<Name "deepOrange">]
    member val DeepOrange = X<PaletteIntention>
    [<Name "deepPurple">]
    member val DeepPurple = X<PaletteIntention>
    [<Name "green">]
    member val Green = X<PaletteIntention>
    [<Name "grey">]
    member val Grey = X<PaletteIntention>
    [<Name "indigo">]
    member val Indigo = X<PaletteIntention>
    [<Name "lightBlue">]
    member val LightBlue = X<PaletteIntention>
    [<Name "lightGreen">]
    member val LightGreen = X<PaletteIntention>
    [<Name "lime">]
    member val Lime = X<PaletteIntention>
    [<Name "orange">]
    member val Orange = X<PaletteIntention>
    [<Name "pink">]
    member val Pink = X<PaletteIntention>
    [<Name "purple">]
    member val Purple = X<PaletteIntention>
    [<Name "red">]
    member val Red = X<PaletteIntention>
    [<Name "teal">]
    member val Teal = X<PaletteIntention>
    [<Name "yellow">]
    member val Yellow = X<PaletteIntention>

[<Stub>]
type internal MUI =
    member this.colors = X<Colors>
    member this.withStyles(styles: Theme -> obj) = X<(Styles -> #React.Component<Styles, _>) -> React.Class>
    member this.createMuiTheme(config: Theme) = X<Theme>
    member this.MuiThemeProvider = X<React.Class>
    member this.CssBaseline = X<React.Class>

module MUI =

    [<Inline "$global['material-ui']">]
    let internal MUI = X<MUI>

    [<Macro(typeof<React.Macros.Make>, 1); Inline>]
    let WithStyles styles (ctor: Styles -> #React.Component<Styles, _>) : React.Element =
        React.CreateElement(MUI.withStyles styles ctor, null)

    [<Inline>]
    let CreateTheme config =
        MUI.createMuiTheme(config)

    [<Inline>]
    let ThemeProvider (theme: Theme) (children: seq<React.Element>) =
        React.CreateElement(MUI.MuiThemeProvider, New ["theme" => theme], Array.ofSeq children)

    [<Inline>]
    let CssBaseline () : React.Element =
        React.CreateElement(MUI.CssBaseline, null)

    [<Inline>]
    let Colors = MUI.colors

[<assembly: Require(typeof<Resources.MaterialUI>)>]
do ()
