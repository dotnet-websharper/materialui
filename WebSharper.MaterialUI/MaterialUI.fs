namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript
open WebSharper.React

module internal ComponentMacros =
    open WebSharper.Core
    open WebSharper.Core.AST
    open WebSharper.React.Macros

    type Component() =
        inherit Macro()

        override this.TranslateCall(call) =
            callElt
                (GlobalAccess <| Hashed [call.Method.Entity.Value.MethodName; "material-ui"])
                (callNewOrNull call.Arguments.[0])
                call.Arguments.[1]
            |> MacroOk

[<Stub; Name "material-ui">]
module MUI =

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

    [<Stub; Name "material-ui.colors">]
    type Colors =
        [<Name "amber">]
        static member Amber = X<PaletteIntention>
        [<Name "blue">]
        static member Blue = X<PaletteIntention>
        [<Name "blueGrey">]
        static member BlueGrey = X<PaletteIntention>
        [<Name "brown">]
        static member Brown = X<PaletteIntention>
        [<Name "common">]
        static member Common = X<PaletteIntention>
        [<Name "cyan">]
        static member Cyan = X<PaletteIntention>
        [<Name "deepOrange">]
        static member DeepOrange = X<PaletteIntention>
        [<Name "deepPurple">]
        static member DeepPurple = X<PaletteIntention>
        [<Name "green">]
        static member Green = X<PaletteIntention>
        [<Name "grey">]
        static member Grey = X<PaletteIntention>
        [<Name "indigo">]
        static member Indigo = X<PaletteIntention>
        [<Name "lightBlue">]
        static member LightBlue = X<PaletteIntention>
        [<Name "lightGreen">]
        static member LightGreen = X<PaletteIntention>
        [<Name "lime">]
        static member Lime = X<PaletteIntention>
        [<Name "orange">]
        static member Orange = X<PaletteIntention>
        [<Name "pink">]
        static member Pink = X<PaletteIntention>
        [<Name "purple">]
        static member Purple = X<PaletteIntention>
        [<Name "red">]
        static member Red = X<PaletteIntention>
        [<Name "teal">]
        static member Teal = X<PaletteIntention>
        [<Name "yellow">]
        static member Yellow = X<PaletteIntention>

    let private withStyles (styles: CompleteTheme -> obj) = X<(Styles -> #React.Component<Styles, _>) -> React.Class>

    [<Macro(typeof<React.Macros.Make>, 1); Inline>]
    let WithStyles styles (ctor: Styles -> #React.Component<Styles, _>) : React.Element =
        React.CreateElement(withStyles styles ctor, null)

    [<Name "createMuiTheme">]
    let CreateTheme (config: Theme) = X<CompleteTheme>

    let private MuiThemeProvider = X<React.Class>

    [<Inline>]
    let ThemeProvider (theme: Theme) (children: seq<React.Element>) =
        React.CreateElement(MuiThemeProvider, New ["theme" => theme], Array.ofSeq children)

    [<Name "CssBaseline">]
    let private CssBaseline_ = X<React.Class>

    [<Inline>]
    let CssBaseline () : React.Element =
        React.CreateElement(CssBaseline_, null)

    // BEGIN components

    [<Name "AppBar">]
    let private AppBar_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let AppBar props children = React.Element AppBar_ props children

    [<Name "Avatar">]
    let private Avatar_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Avatar props children = React.Element Avatar_ props children

    [<Name "Backdrop">]
    let private Backdrop_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Backdrop props children = React.Element Backdrop_ props children

    [<Name "Badge">]
    let private Badge_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Badge props children = React.Element Badge_ props children

    [<Name "BottomNavigation">]
    let private BottomNavigation_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let BottomNavigation props children = React.Element BottomNavigation_ props children

    [<Name "BottomNavigationAction">]
    let private BottomNavigationAction_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let BottomNavigationAction props children = React.Element BottomNavigationAction_ props children

    [<Name "Button">]
    let private Button_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Button props children = React.Element Button_ props children

    [<Name "ButtonBase">]
    let private ButtonBase_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ButtonBase props children = React.Element ButtonBase_ props children

    [<Name "Card">]
    let private Card_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Card props children = React.Element Card_ props children

    [<Name "CardActions">]
    let private CardActions_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let CardActions props children = React.Element CardActions_ props children

    [<Name "CardContent">]
    let private CardContent_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let CardContent props children = React.Element CardContent_ props children

    [<Name "CardHeader">]
    let private CardHeader_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let CardHeader props children = React.Element CardHeader_ props children

    [<Name "CardMedia">]
    let private CardMedia_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let CardMedia props children = React.Element CardMedia_ props children

    [<Name "Checkbox">]
    let private Checkbox_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Checkbox props children = React.Element Checkbox_ props children

    [<Name "Chip">]
    let private Chip_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Chip props children = React.Element Chip_ props children

    [<Name "CilcularProgress">]
    let private CilcularProgress_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let CilcularProgress props children = React.Element CilcularProgress_ props children

    [<Name "ClickAwayListener">]
    let private ClickAwayListener_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ClickAwayListener props children = React.Element ClickAwayListener_ props children

    [<Name "Collapse">]
    let private Collapse_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Collapse props children = React.Element Collapse_ props children

    [<Name "Dialog">]
    let private Dialog_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Dialog props children = React.Element Dialog_ props children

    [<Name "DialogActions">]
    let private DialogActions_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let DialogActions props children = React.Element DialogActions_ props children

    [<Name "DialogContent">]
    let private DialogContent_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let DialogContent props children = React.Element DialogContent_ props children

    [<Name "DialogContentText">]
    let private DialogContentText_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let DialogContentText props children = React.Element DialogContentText_ props children

    [<Name "DialogTitle">]
    let private DialogTitle_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let DialogTitle props children = React.Element DialogTitle_ props children

    [<Name "Divider">]
    let private Divider_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Divider props children = React.Element Divider_ props children

    [<Name "Drawer">]
    let private Drawer_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Drawer props children = React.Element Drawer_ props children

    [<Name "ExpansionPanel">]
    let private ExpansionPanel_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ExpansionPanel props children = React.Element ExpansionPanel_ props children

    [<Name "ExpansionPanelActions">]
    let private ExpansionPanelActions_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ExpansionPanelActions props children = React.Element ExpansionPanelActions_ props children

    [<Name "ExpansionPanelDetails">]
    let private ExpansionPanelDetails_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ExpansionPanelDetails props children = React.Element ExpansionPanelDetails_ props children

    [<Name "ExpansionPanelSummary">]
    let private ExpansionPanelSummary_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ExpansionPanelSummary props children = React.Element ExpansionPanelSummary_ props children

    [<Name "Fade">]
    let private Fade_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Fade props children = React.Element Fade_ props children

    [<Name "FormControl">]
    let private FormControl_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let FormControl props children = React.Element FormControl_ props children

    [<Name "FormControlLabel">]
    let private FormControlLabel_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let FormControlLabel props children = React.Element FormControlLabel_ props children

    [<Name "FormGroup">]
    let private FormGroup_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let FormGroup props children = React.Element FormGroup_ props children

    [<Name "FormHelperText">]
    let private FormHelperText_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let FormHelperText props children = React.Element FormHelperText_ props children

    [<Name "FormLabel">]
    let private FormLabel_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let FormLabel props children = React.Element FormLabel_ props children

    [<Name "Grid">]
    let private Grid_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Grid props children = React.Element Grid_ props children

    [<Name "GridList">]
    let private GridList_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let GridList props children = React.Element GridList_ props children

    [<Name "GridListTile">]
    let private GridListTile_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let GridListTile props children = React.Element GridListTile_ props children

    [<Name "GridListTileBar">]
    let private GridListTileBar_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let GridListTileBar props children = React.Element GridListTileBar_ props children

    [<Name "Grow">]
    let private Grow_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Grow props children = React.Element Grow_ props children

    [<Name "Hidden">]
    let private Hidden_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Hidden props children = React.Element Hidden_ props children

    [<Name "Icon">]
    let private Icon_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Icon props children = React.Element Icon_ props children

    [<Name "IconButton">]
    let private IconButton_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let IconButton props children = React.Element IconButton_ props children

    [<Name "Input">]
    let private Input_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Input props children = React.Element Input_ props children

    [<Name "InputAdornment">]
    let private InputAdornment_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let InputAdornment props children = React.Element InputAdornment_ props children

    [<Name "InputLabel">]
    let private InputLabel_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let InputLabel props children = React.Element InputLabel_ props children

    [<Name "LinearProgress">]
    let private LinearProgress_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let LinearProgress props children = React.Element LinearProgress_ props children

    [<Name "List">]
    let private List_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let List props children = React.Element List_ props children

    [<Name "ListItem">]
    let private ListItem_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ListItem props children = React.Element ListItem_ props children

    [<Name "ListItemAvatar">]
    let private ListItemAvatar_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ListItemAvatar props children = React.Element ListItemAvatar_ props children

    [<Name "ListItemIcon">]
    let private ListItemIcon_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ListItemIcon props children = React.Element ListItemIcon_ props children

    [<Name "ListItemSecondaryAction">]
    let private ListItemSecondaryAction_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ListItemSecondaryAction props children = React.Element ListItemSecondaryAction_ props children

    [<Name "ListItemText">]
    let private ListItemText_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ListItemText props children = React.Element ListItemText_ props children

    [<Name "ListSubheader">]
    let private ListSubheader_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let ListSubheader props children = React.Element ListSubheader_ props children

    [<Name "Menu">]
    let private Menu_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Menu props children = React.Element Menu_ props children

    [<Name "MenuItem">]
    let private MenuItem_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let MenuItem props children = React.Element MenuItem_ props children

    [<Name "MenuList">]
    let private MenuList_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let MenuList props children = React.Element MenuList_ props children

    [<Name "MobileStepper">]
    let private MobileStepper_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let MobileStepper props children = React.Element MobileStepper_ props children

    [<Name "Modal">]
    let private Modal_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Modal props children = React.Element Modal_ props children

    [<Name "NativeSelect">]
    let private NativeSelect_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let NativeSelect props children = React.Element NativeSelect_ props children

    [<Name "NoSsr">]
    let private NoSsr_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let NoSsr props children = React.Element NoSsr_ props children

    [<Name "Paper">]
    let private Paper_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Paper props children = React.Element Paper_ props children

    [<Name "Popover">]
    let private Popover_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Popover props children = React.Element Popover_ props children

    [<Name "Popper">]
    let private Popper_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Popper props children = React.Element Popper_ props children

    [<Name "Portal">]
    let private Portal_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Portal props children = React.Element Portal_ props children

    [<Name "Radio">]
    let private Radio_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Radio props children = React.Element Radio_ props children

    [<Name "RadioGroup">]
    let private RadioGroup_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let RadioGroup props children = React.Element RadioGroup_ props children

    [<Name "RootRef">]
    let private RootRef_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let RootRef props children = React.Element RootRef_ props children

    [<Name "Select">]
    let private Select_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Select props children = React.Element Select_ props children

    [<Name "Slide">]
    let private Slide_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Slide props children = React.Element Slide_ props children

    [<Name "Snackbar">]
    let private Snackbar_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Snackbar props children = React.Element Snackbar_ props children

    [<Name "SnackbarContent">]
    let private SnackbarContent_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let SnackbarContent props children = React.Element SnackbarContent_ props children

    [<Name "Step">]
    let private Step_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Step props children = React.Element Step_ props children

    [<Name "StepButton">]
    let private StepButton_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let StepButton props children = React.Element StepButton_ props children

    [<Name "StepConnector">]
    let private StepConnector_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let StepConnector props children = React.Element StepConnector_ props children

    [<Name "StepContent">]
    let private StepContent_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let StepContent props children = React.Element StepContent_ props children

    [<Name "StepIcon">]
    let private StepIcon_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let StepIcon props children = React.Element StepIcon_ props children

    [<Name "StepLabel">]
    let private StepLabel_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let StepLabel props children = React.Element StepLabel_ props children

    [<Name "Stepper">]
    let private Stepper_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Stepper props children = React.Element Stepper_ props children

    [<Name "SvgIcon">]
    let private SvgIcon_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let SvgIcon props children = React.Element SvgIcon_ props children

    [<Name "SwipeableDrawer">]
    let private SwipeableDrawer_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let SwipeableDrawer props children = React.Element SwipeableDrawer_ props children

    [<Name "Switch">]
    let private Switch_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Switch props children = React.Element Switch_ props children

    [<Name "Tab">]
    let private Tab_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Tab props children = React.Element Tab_ props children

    [<Name "Table">]
    let private Table_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Table props children = React.Element Table_ props children

    [<Name "TableBody">]
    let private TableBody_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TableBody props children = React.Element TableBody_ props children

    [<Name "TableCell">]
    let private TableCell_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TableCell props children = React.Element TableCell_ props children

    [<Name "TableFooter">]
    let private TableFooter_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TableFooter props children = React.Element TableFooter_ props children

    [<Name "TableHead">]
    let private TableHead_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TableHead props children = React.Element TableHead_ props children

    [<Name "TablePagination">]
    let private TablePagination_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TablePagination props children = React.Element TablePagination_ props children

    [<Name "TableRow">]
    let private TableRow_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TableRow props children = React.Element TableRow_ props children

    [<Name "TableSortLabel">]
    let private TableSortLabel_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TableSortLabel props children = React.Element TableSortLabel_ props children

    [<Name "Tabs">]
    let private Tabs_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Tabs props children = React.Element Tabs_ props children

    [<Name "TextField">]
    let private TextField_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TextField props children = React.Element TextField_ props children

    [<Name "Toolbar">]
    let private Toolbar_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Toolbar props children = React.Element Toolbar_ props children

    [<Name "Tooltip">]
    let private Tooltip_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Tooltip props children = React.Element Tooltip_ props children

    [<Name "TouchRipple">]
    let private TouchRipple_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let TouchRipple props children = React.Element TouchRipple_ props children

    [<Name "Typography">]
    let private Typography_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Typography props children = React.Element Typography_ props children

    [<Name "Zoom">]
    let private Zoom_ = X<string>
    [<Inline; Macro(typeof<ComponentMacros.Component>)>]
    let Zoom props children = React.Element Zoom_ props children

    // END components

[<assembly: Require(typeof<Resources.MaterialUI>)>]
do ()
