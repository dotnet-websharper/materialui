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
type Spacing [<Inline "{}">] () =
    [<Name "unit">]
    member val Unit = X<int> with get, set

[<Stub>]
type BreakpointValues [<Inline "{}">] () =
    [<Name "xs">]
    member val Xs = X<int> with get, set
    [<Name "sm">]
    member val Sm = X<int> with get, set
    [<Name "md">]
    member val Md = X<int> with get, set
    [<Name "lg">]
    member val Lg = X<int> with get, set
    [<Name "xl">]
    member val Xl = X<int> with get, set

type BreakpointKey =
    | [<Constant "xs">] Xs
    | [<Constant "sm">] Sm
    | [<Constant "md">] Md
    | [<Constant "lg">] Lg
    | [<Constant "xl">] Xl

[<Stub>]
type Breakpoints [<Inline "{}">] () =
    [<Name "values">]
    member val Values = X<BreakpointValues> with get, set
    [<Name "up">]
    member this.Up(key: BreakpointKey) = X<string>
    [<Name "down">]
    member this.Down(key: BreakpointKey) = X<string>
    [<Name "only">]
    member this.Only(key: BreakpointKey) = X<string>
    [<Name "between">]
    member this.Between(start: BreakpointKey, ``end``: BreakpointKey) = X<string>

type Direction =
    | [<Constant "ltr">] Ltr
    | [<Constant "rtl">] Rtl

[<Stub>]
type Mixins private () =
    [<Name "gutters">]
    member this.Gutters() = X<obj>
    [<Name "gutters">]
    member this.Gutters(styles: obj) = X<obj>
    [<Name "toolbar">]
    member val Toolbar = X<obj>

[<Stub>]
type TransitionDurations [<Inline "{}">] () =
    [<Name "complex">]
    member val Complex = X<int> with get, set
    [<Name "enteringScreen">]
    member val EnteringScreen = X<int> with get, set
    [<Name "leavingScreen">]
    member val LeavingScreen = X<int> with get, set
    [<Name "short">]
    member val Short = X<int> with get, set
    [<Name "shorter">]
    member val Shorter = X<int> with get, set
    [<Name "shortest">]
    member val Shortest = X<int> with get, set
    [<Name "standard">]
    member val Standard = X<int> with get, set

[<Stub>]
type TransitionEasing [<Inline "{}">] () =
    [<Name "easeIn">]
    member val EaseIn = X<string> with get, set
    [<Name "easeOut">]
    member val EaseOut = X<string> with get, set
    [<Name "easeInOut">]
    member val EaseInOut = X<string> with get, set
    [<Name "sharp">]
    member val Sharp = X<string> with get, set

[<Stub>]
type Transitions [<Inline "{}">] () =
    [<Name "create">]
    member this.Create() = X<string>
    [<Name "create">]
    member this.Create(props: string[]) = X<string>
    [<Name "create">]
    member this.Create(props: string[], options: obj) = X<string>
    [<Name "duration">]
    member val Duration = X<TransitionDurations> with get, set
    [<Name "easing">]
    member val Easing = X<TransitionEasing> with get, set
    [<Name "getAutoHeightDuration">]
    member this.GetAutoHeightDuration(height: int) = X<int>

[<Stub>]
type Typography [<Inline "{}">] () =
    [<Name "body1">]
    member val Body1 = X<obj> with get, set
    [<Name "body2">]
    member val Body2 = X<obj> with get, set
    [<Name "button">]
    member val Button = X<obj> with get, set
    [<Name "caption">]
    member val Caption = X<obj> with get, set
    [<Name "display1">]
    member val Display1 = X<obj> with get, set
    [<Name "display2">]
    member val Display2 = X<obj> with get, set
    [<Name "display3">]
    member val Display3 = X<obj> with get, set
    [<Name "display4">]
    member val Display4 = X<obj> with get, set
    [<Name "headline">]
    member val Headline = X<obj> with get, set
    [<Name "subheading">]
    member val Subheading = X<obj> with get, set
    [<Name "title">]
    member val Title = X<obj> with get, set
    [<Name "fontFamily">]
    member val FontFamily = X<string> with get, set
    [<Name "fontSize">]
    member val FontSize = X<int> with get, set
    [<Name "fontWeightLight">]
    member val FontWeightLight = X<int> with get, set
    [<Name "fontWeightMedium">]
    member val FontWeightMedium = X<int> with get, set
    [<Name "fontWeightRegular">]
    member val FontWeightRegular = X<int> with get, set
    [<Name "pxToRem">]
    member this.PxToRem(px: float) = X<float>
    [<Name "round">]
    member this.Round(px: float) = X<float>

[<Stub>]
type ZIndex [<Inline "{}">] () =
    [<Name "appBar">]
    member val AppBar = X<int> with get, set
    [<Name "drawer">]
    member val Drawer = X<int> with get, set
    [<Name "mobileStepper">]
    member val MobileStepper = X<int> with get, set
    [<Name "modal">]
    member val Modal = X<int> with get, set
    [<Name "snackbar">]
    member val Snackbar = X<int> with get, set
    [<Name "tooltip">]
    member val Tooltip = X<int> with get, set

[<Stub>]
type Theme [<Inline "{}">] () =
    [<Name "breakpoints">]
    member val Breakpoints = X<Breakpoints> with get, set
    [<Name "direction">]
    member val Direction = X<Direction> with get, set
    [<Name "overrides">]
    member val Overrides = X<obj> with get, set
    [<Name "palette">]
    member val Palette = X<Palette> with get, set
    [<Name "props">]
    member val Props = X<obj> with get, set
    [<Name "shape">]
    member val Shape = X<obj> with get, set
    [<Name "spacing">]
    member val Spacing = X<Spacing> with get, set
    [<Name "typography">]
    member val Typography = X<Typography> with get, set
    [<Name "zIndex">]
    member val ZIndex = X<ZIndex> with get, set
    [<Name "transitions">]
    member val Transitions = X<Transitions> with get, set

[<Stub>]
type CompleteTheme private () =
    inherit Theme()
    [<Name "mixins">]
    member val Mixins = X<Mixins>
    [<Name "shadows">]
    member val Shadows = X<string[]>

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
    member this.withStyles(styles: CompleteTheme -> obj) = X<(Styles -> #React.Component<Styles, _>) -> React.Class>
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
