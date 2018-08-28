namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript
open WebSharper.React
open WebSharper.React.Bindings

module internal AttrMacros =
    open WebSharper.Core
    open WebSharper.Core.AST
    module M = WebSharper.Core.Metadata
    module I = WebSharper.Core.AST.IgnoreSourcePos

    type MUIComponentAttr() =
        inherit Macro()

        static let rMUI = typeof<MUI.Theme>.Assembly.GetType("WebSharper.MaterialUI.MUI")
        static let MUI = Reflection.ReadTypeDefinition rMUI
        let jsMUIComponent name = GlobalAccess <| Hashed [name; "material-ui"]

        override this.TranslateCall(call) =
            match call.Arguments with
            | [I.Function([props],
                I.Return(
                    I.Function([children],
                        I.Return(
                            I.Call(None, ty, meth, [I.Var props'; I.Var children'])))))]
                when props = props' &&
                    children = children' &&
                    ty = NonGeneric MUI ->
                NewArray [!~(String "component"); jsMUIComponent meth.Entity.Value.MethodName]
                |> MacroOk
            | [x] ->
                MacroError """attr.``component`` must be used with a string (eg: "div"), a MUI component (eg: MUI.Button) or a React component class."""
            | _ ->
                MacroError "Invalid use of ComponentAttr macro"

type attr =
    [<Inline>]
    static member absolute (b: bool) = "absolute" => b
    [<Inline>]
    static member action (f: obj -> unit) = "action" => f
    [<Inline>]
    static member action (e: React.Element) = "action" => e
    [<Inline>]
    static member actionIcon (e: React.Element) = "actionIcon" => e
    [<Inline>]
    static member actionPosition (p: MUI.HPosition) = "actionPosition" => p
    [<Inline>]
    static member ActionsComponent (tag: string) = "ActionsComponent" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member ActionsComponent (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "ActionsComponent" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member ActionsComponent<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "ActionsComponent" => ctor
    [<Inline>]
    static member active (b: bool) = "active" => b
    [<Inline>]
    static member activeStep (i: int) = "activeStep" => i
    [<Inline>]
    static member align (a: MUI.TextAlign) = "align" => a
    [<Inline>]
    static member alignContent (a: MUI.AlignContent) = "alignContent" => a
    [<Inline>]
    static member alignItems (a: MUI.AlignItems) = "alignItems" => a
    [<Inline>]
    static member alternativeLabel (b: bool) = "alternativeLabel" => b
    [<Inline>]
    static member anchor (a: MUI.Anchor) = "anchor" => a
    [<Inline>]
    static member anchorEl (e: Dom.Element) = "anchorEl" => e
    [<Inline>]
    static member anchorOrigin (o: MUI.Origin) = "anchorOrigin" => o
    [<Inline>]
    static member anchorPosition (p: MUI.AnchorPosition) = "anchorPosition" => p
    [<Inline>]
    static member anchorReference (r: MUI.AnchorReference) = "anchorReference" => r
    [<Inline>]
    static member autoComplete (s: string) = "autoComplete" => s
    [<Inline>]
    static member autoFocus (b: bool) = "autoFocus" => b
    [<Inline>]
    static member autoHideDuration (i: int) = "autoHideDuration" => i
    [<Inline>]
    static member autoWidth (b: bool) = "autoWidth" => b
    [<Inline>]
    static member avatar (e: React.Element) = "action" => e
    [<Inline>]
    static member badgeContent (e: React.Element) = "badgeContent" => e
    [<Inline>]
    static member backButton (e: React.Element) = "backButton" => e
    [<Inline>]
    static member BackdropComponent (tag: string) = "BackdropComponent" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member BackdropComponent (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "BackdropComponent" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member BackdropComponent<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "BackdropComponent" => ctor
    [<Inline>]
    static member BackdropProps (o: obj) = "BackdropProps" => o
    [<Inline>]
    static member backIconButtonProps (o: obj) = "backIconButtonProps" => o
    [<Inline>]
    static member button (b: bool) = "button" => b
    [<Inline>]
    static member buttonRef (r: React.Ref) = "buttonRef" => r
    [<Inline>]
    static member cellHeight (i: int) = "cellHeight" => i
    [<Inline>]
    static member cellHeight (a: MUI.Auto) = "cellHeight" => a
    [<Inline>]
    static member centered (b: bool) = "centered" => b
    [<Inline>]
    static member centerRipple (b: bool) = "centerRipple" => b
    [<Inline>]
    static member ``checked`` (b: bool) = "checked" => b
    [<Inline>]
    static member checkedIcon (e: React.Element) = "checkedIcon" => e
    [<Inline>]
    static member classes (o: obj) = "classes" => o
    [<Inline>]
    static member clickable (b: bool) = "clickable" => b
    [<Inline>]
    static member collapseHeight (s: string) = "collapseHeight" => s
    [<Inline>]
    static member CollapseProps (o: obj) = "CollapseProps" => o
    [<Inline>]
    static member color (c: MUI.Color) = "color" => c
    [<Inline>]
    static member cols (i: int) = "cols" => i
    [<Inline>]
    static member completed (b: bool) = "completed" => b
    [<Inline>]
    static member ``component`` (tag: string) = "component" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member ``component`` (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "component" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member ``component``<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "component" => ctor
    [<Inline>]
    static member connector (e: React.Element) = "connector" => e
    [<Inline>]
    static member container = "container" => true
    [<Inline>]
    static member ContainerComponent (tag: string) = "ContainerComponent" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member ContainerComponent (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "ContainerComponent" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member ContainerComponent<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "ContainerComponent" => ctor
    [<Inline>]
    static member ContainerProps (o: obj) = "ContainerProps" => o
    [<Inline>]
    static member ContentProps (o: obj) = "ContentProps" => o
    [<Inline>]
    static member control (e: React.Element) = "control" => e
    [<Inline>]
    static member count (i: int) = "count" => i
    [<Inline>]
    static member defaultExpanded (b: bool) = "defaultExpanded" => b
    [<Inline>]
    static member defaultValue (s: string) = "defaultValue" => s
    [<Inline>]
    static member defaultValue (i: int) = "defaultValue" => i
    [<Inline>]
    static member defer (b: bool) = "defer" => b
    [<Inline>]
    static member deleteIcon (e: React.Element) = "deleteIcon" => e
    [<Inline>]
    static member dense (b: bool) = "dense" => b
    [<Inline>]
    static member direction (d: MUI.FlexDirection) = "direction" => d
    [<Inline>]
    static member direction (d: MUI.Direction) = "direction" => d
    [<Inline>]
    static member direction (d: MUI.SortDirection) = "direction" => d
    [<Inline>]
    static member disableActionSpacing (b: bool) = "disableActionSpacing" => b
    [<Inline>]
    static member disableAnimation (b: bool) = "disableAnimation" => b
    [<Inline>]
    static member disableAutoFocus (b: bool) = "disableAutoFocus" => b
    [<Inline>]
    static member disableAutoFocusItem (b: bool) = "disableAutoFocusItem" => b
    [<Inline>]
    static member disableBackdropClick (b: bool) = "disableBackdropClick" => b
    [<Inline>]
    static member disableBackdropTransition (b: bool) = "disableBackdropTransition" => b
    [<Inline>]
    static member disabled (b: bool) = "disabled" => b
    [<Inline>]
    static member disableDiscovery (b: bool) = "disableDiscovery" => b
    [<Inline>]
    static member disableEnforceFocus (b: bool) = "disableEnforceFocus" => b
    [<Inline>]
    static member disableEscapeKeyDown (b: bool) = "disableEscapeKeyDown" => b
    [<Inline>]
    static member disableFocusListener (b: bool) = "disableFocusListener" => b
    [<Inline>]
    static member disableFocusRipple (b: bool) = "disableFocusRipple" => b
    [<Inline>]
    static member disableGutters (b: bool) = "disableGutters" => b
    [<Inline>]
    static member disableHoverListener (b: bool) = "disableHoverListener" => b
    [<Inline>]
    static member disablePadding (b: bool) = "disablePadding" => b
    [<Inline>]
    static member disablePortal (b: bool) = "disablePortal" => b
    [<Inline>]
    static member disableRestoreFocus (b: bool) = "disableRestoreFocus" => b
    [<Inline>]
    static member disableRipple (b: bool) = "disableRipple" => b
    [<Inline>]
    static member disableSticky (b: bool) = "disableSticky" => b
    [<Inline>]
    static member disableSwipeToOpen (b: bool) = "disableSwipeToOpen" => b
    [<Inline>]
    static member disableTouchListener (b: bool) = "disableTouchListener" => b
    [<Inline>]
    static member disableTypography (b: bool) = "disableTypography" => b
    [<Inline>]
    static member disableUnderline (b: bool) = "disableUnderline" => b
    [<Inline>]
    static member disableWindowBlurListener (b: bool) = "disableWindowBlurListener" => b
    [<Inline>]
    static member displayEmpty (b: bool) = "displayEmpty" => b
    [<Inline>]
    static member divider (b: bool) = "divider" => b
    [<Inline>]
    static member elevation (e: int) = "elevation" => e
    [<Inline>]
    static member endAdornment (e: React.Element) = "endAdornment" => e
    [<Inline>]
    static member enterDelay (i: int) = "enterDelay" => i
    [<Inline>]
    static member enterTouchDelay (i: int) = "enterTouchDelay" => i
    [<Inline>]
    static member error (b: bool) = "error" => b
    [<Inline>]
    static member expanded (b: bool) = "expanded" => b
    [<Inline>]
    static member expandIcon (e: React.Element) = "expandIcon" => e
    [<Inline>]
    static member fallback (b: bool) = "fallback" => b
    [<Inline>]
    static member filled (b: bool) = "filled" => b
    [<Inline>]
    static member focused (b: bool) = "focused" => b
    [<Inline>]
    static member focusRipple (b: bool) = "focusRipple" => b
    [<Inline>]
    static member focusVisibleClassName (b: bool) = "focusVisibleClassName" => b
    [<Inline>]
    static member fontSize (s: MUI.FontSize) = "fontSize" => s
    [<Inline>]
    static member FormHelperTextProps (o: obj) = "FormHelperTextProps" => o
    [<Inline>]
    static member FormLabelClasses (o: obj) = "FormLabelClasses" => o
    [<Inline>]
    static member fullScreen (b: bool) = "fullScreen" => b
    [<Inline>]
    static member fullWidth (b: bool) = "fullWidth" => b
    [<Inline>]
    static member getContentAnchorEl (f: unit -> Dom.Element) = "getContentAnchorEl" => f
    [<Inline>]
    static member gutterBottom (b: bool) = "gutterBottom" => b
    [<Inline>]
    static member headlineMapping (m: MUI.HeadlineMapping) = "headlineMapping" => m
    [<Inline>]
    static member helperText (e: React.Element) = "helperText" => e
    [<Inline>]
    static member hideBackdrop (b: bool) = "hideBackdrop" => b
    [<Inline>]
    static member hover (b: bool) = "hover" => b
    [<Inline>]
    static member icon (e: React.Element) = "icon" => e
    [<Inline>]
    static member IconButtonProps (o: obj) = "IconButtonProps" => o
    [<Inline>]
    static member IconComponent (tag: string) = "IconComponent" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member IconComponent (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "IconComponent" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member IconComponent<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "IconComponent" => ctor
    [<Inline>]
    static member image (s: string) = "image" => s
    [<Inline>]
    static member imgProps (o: obj) = "imgProps" => o
    [<Inline>]
    static member implementation (i: MUI.Implementation) = "implementation" => i
    [<Inline>]
    static member ``in`` (b: bool) = "in" => b
    [<Inline>]
    static member indeterminate (b: bool) = "indeterminate" => b
    [<Inline>]
    static member indeterminateIcon (e: React.Element) = "indeterminateIcon" => e
    [<Inline>]
    static member indicatorColor (c: MUI.Color) = "indicatorColor" => c
    [<Inline>]
    static member initialWidth (w: MUI.SizeKey) = "initialWidth" => w
    [<Inline>]
    static member input (e: React.Element) = "input" => e
    [<Inline>]
    static member inputComponent (tag: string) = "inputComponent" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member inputComponent (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "inputComponent" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member inputComponent<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "inputComponent" => ctor
    [<Inline>]
    static member InputLabelProps (o: obj) = "InputLabelProps" => o
    [<Inline>]
    static member inputProps (o: obj) = "inputProps" => o
    [<Inline>]
    static member InputProps (o: obj) = "InputProps" => o
    [<Inline>]
    static member inputRef (r: React.Ref) = "inputRef" => r
    [<Inline>]
    static member inset (b: bool) = "inset" => b
    [<Inline>]
    static member invisible (b: bool) = "invisible" => b
    [<Inline>]
    static member item = "item" => true
    [<Inline>]
    static member justify (j: MUI.Justify) = "justify" => j
    [<Inline>]
    static member keepMounted (b: bool) = "keepMounted" => b
    [<Inline>]
    static member key (o: obj) = "key" => o
    [<Inline>]
    static member label (e: React.Element) = "label" => e
    [<Inline>]
    static member labelDisplayedRows (f: MUI.LabelDisplayedRowsArgs -> string) = "labelDisplayedRows" => f
    [<Inline>]
    static member labelPlacement (p: MUI.Placement) = "labelPlacement" => p
    [<Inline>]
    static member labelRowsPerPage (e: React.Element) = "labelRowsPerPage" => e
    [<Inline>]
    static member leaveDelay (i: int) = "leaveDelay" => i
    [<Inline>]
    static member leaveTouchDelay (i: int) = "leaveTouchDelay" => i
    [<Inline>]
    static member lg (b: bool) = "lg" => b
    [<Inline>]
    static member lg (i: int) = "lg" => i
    [<Inline>]
    static member lg (a: MUI.Auto) = "lg" => a
    [<Inline>]
    static member lgDown (b: bool) = "lgDown" => b
    [<Inline>]
    static member lgUp (b: bool) = "lgUp" => b
    [<Inline>]
    static member light (b: bool) = "light" => b
    [<Inline>]
    static member LinearProgressProps (o: obj) = "LinearProgressProps" => o
    [<Inline>]
    static member manager (m: MUI.ModalManager) = "manager" => m
    [<Inline>]
    static member margin (m: MUI.Margin) = "margin" => m
    [<Inline>]
    static member marginThreshold (i: int) = "marginThreshold" => i
    [<Inline>]
    static member maxWidth (b: bool) = "maxWidth" => b
    [<Inline>]
    static member maxWidth (w: MUI.MaxWidth) = "maxWidth" => w
    [<Inline>]
    static member md (b: bool) = "md" => b
    [<Inline>]
    static member md (i: int) = "md" => i
    [<Inline>]
    static member md (a: MUI.Auto) = "md" => a
    [<Inline>]
    static member mdDown (b: bool) = "mdDown" => b
    [<Inline>]
    static member mdUp (b: bool) = "mdUp" => b
    [<Inline>]
    static member MenuListProps (o: obj) = "MenuListProps" => o
    [<Inline>]
    static member MenuProps (o: obj) = "MenuProps" => o
    [<Inline>]
    static member message (e: React.Element) = "message" => e
    [<Inline>]
    static member mini (b: bool) = "mini" => b
    [<Inline>]
    static member ModalClasses (o: obj) = "ModalClasses" => o
    [<Inline>]
    static member ModalProps (o: obj) = "ModalProps" => o
    [<Inline>]
    static member modifiers (o: obj) = "modifiers" => o
    [<Inline>]
    static member mouseEvent (b: bool) = "mouseEvent" => b
    [<Inline>]
    static member mouseEvent (e: MUI.MouseEvent) = "mouseEvent" => e
    [<Inline>]
    static member multiline (b: bool) = "multiline" => b
    [<Inline>]
    static member multiple (b: bool) = "multiple" => b
    [<Inline>]
    static member native (b: bool) = "native" => b
    [<Inline>]
    static member nativeColor (s: string) = "nativeColor" => s
    [<Inline>]
    static member nextButton (e: React.Element) = "nextButton" => e
    [<Inline>]
    static member nextIconButtonProps (o: obj) = "nextIconButtonProps" => o
    [<Inline>]
    static member nonLinear (b: bool) = "nonLinear" => b
    [<Inline>]
    static member noWrap (b: bool) = "noWrap" => b
    [<Inline>]
    static member numeric (b: bool) = "numeric" => b
    [<Inline>]
    static member only (o: MUI.SizeKey) = "only" => o
    [<Inline>]
    static member only (o: MUI.SizeKey[]) = "only" => o
    [<Inline>]
    static member ``open`` (b: bool) = "open" => b
    [<Inline>]
    static member optional (b: bool) = "optional" => b
    [<Inline>]
    static member orientation (o: MUI.Orientation) = "orientation" => o
    [<Inline>]
    static member page (i: int) = "page" => i
    [<Inline>]
    static member padding (p: MUI.TablePadding) = "padding" => p
    [<Inline>]
    static member PaperProps (o: obj) = "PaperProps" => o
    [<Inline>]
    static member paragraph (b: bool) = "paragraph" => b
    [<Inline>]
    static member placement (p: MUI.Placement) = "placement" => p
    [<Inline>]
    static member PopoverClasses (o: obj) = "PopoverClasses" => o
    [<Inline>]
    static member popperOptions (o: obj) = "popperOptions" => o
    [<Inline>]
    static member PopperProps (o: obj) = "PopperProps" => o
    [<Inline>]
    static member position (p: MUI.Position) = "position" => p
    [<Inline>]
    static member position (p: MUI.VPosition) = "position" => p
    [<Inline>]
    static member position (p: MUI.Placement) = "position" => p
    [<Inline>]
    static member primary (e: React.Element) = "primary" => e
    [<Inline>]
    static member primaryTypographyProps (o: obj) = "primaryTypographyProps" => o
    [<Inline>]
    static member raised (b: bool) = "raised" => b
    [<Inline>]
    static member readOnly (b: bool) = "readOnly" => b
    [<Inline>]
    static member renderValue<'T> (f: 'T -> React.Element) = "renderValue" => f
    [<Inline>]
    static member required (b: bool) = "required" => b
    [<Inline>]
    static member resumeHideDuration (i: int) = "resumeHideDuration" => i
    [<Inline>]
    static member rootRef (r: React.Ref) = "rootRef" => r
    [<Inline>]
    static member row (b: bool) = "row" => b
    [<Inline>]
    static member rows (i: int) = "rows" => i
    [<Inline>]
    static member rowsPerPage (i: int) = "rowsPerPage" => i
    [<Inline>]
    static member rowsPerPageOptions (i: int[]) = "rowsPerPageOptions" => i
    [<Inline>]
    static member rowsMax (i: int) = "rowsMax" => i
    [<Inline>]
    static member scope (s: string) = "scope" => s
    [<Inline>]
    static member scroll (s: MUI.DialogScroll) = "scroll" => s
    [<Inline>]
    static member scrollable (b: bool) = "scrollable" => b
    [<Inline>]
    static member ScrollButtonComponent (tag: string) = "ScrollButtonComponent" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member ScrollButtonComponent (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "ScrollButtonComponent" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member ScrollButtonComponent<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "ScrollButtonComponent" => ctor
    [<Inline>]
    static member scrollButtons (a: MUI.Auto) = "scrollButtons" => a
    [<Inline>]
    static member scrollButtons (o: MUI.OnOff) = "scrollButtons" => o
    [<Inline>]
    static member secondary (e: React.Element) = "secondary" => e
    [<Inline>]
    static member secondaryTypographyProps (o: obj) = "secondaryTypographyProps" => o
    [<Inline>]
    static member SelectDisplayProps (o: obj) = "SelectDisplayProps" => o
    [<Inline>]
    static member ``select`` (b: bool) = "select" => b
    [<Inline>]
    static member selected (b: bool) = "selected" => b
    [<Inline>]
    static member SelectProps (o: obj) = "SelectProps" => o
    [<Inline>]
    static member showLabels (b: bool) = "showLabels" => b
    [<Inline>]
    static member showLabel (b: bool) = "showLabel" => b
    [<Inline>]
    static member shrink (b: bool) = "shrink" => b
    [<Inline>]
    static member size (s: MUI.Size) = "size" => s
    [<Inline>]
    static member size (n: int) = "size" => n
    [<Inline>]
    static member SlideProps (o: obj) = "SlideProps" => o
    [<Inline>]
    static member sm (b: bool) = "sm" => b
    [<Inline>]
    static member sm (i: int) = "sm" => i
    [<Inline>]
    static member sm (a: MUI.Auto) = "sm" => a
    [<Inline>]
    static member smDown (b: bool) = "smDown" => b
    [<Inline>]
    static member smUp (b: bool) = "smUp" => b
    [<Inline>]
    static member sortDirection (d: MUI.SortDirection) = "sortdirection" => d
    [<Inline>]
    static member sortDirection (b: bool) = "sortdirection" => b
    [<Inline>]
    static member spacing (i: int) = "spacing" => i
    [<Inline>]
    static member square (b: bool) = "square" => b
    [<Inline>]
    static member startAdornment (e: React.Element) = "startAdornment" => e
    [<Inline>]
    static member StepIconProps (o: obj) = "StepIconProps" => o
    [<Inline>]
    static member steps (i: int) = "steps" => i
    [<Inline>]
    static member subheader (e: React.Element) = "subheader" => e
    [<Inline>]
    static member subheaderTypographyProps (o: obj) = "subheaderTypographyProps" => o
    [<Inline>]
    static member subtitle (e: React.Element) = "subtitle" => e
    [<Inline>]
    static member swipeAreaWidth (i: int) = "swipeAreaWidth" => i
    [<Inline>]
    static member TabIndicatorProps (o: obj) = "TabIndicatorProps" => o
    [<Inline>]
    static member textColor (c: MUI.Color) = "textColor" => c
    [<Inline>]
    static member thickness (n: float) = "thickness" => n
    [<Inline>]
    static member timeout (ms: int) = "timeout" => ms
    [<Inline>]
    static member timeout (d: MUI.Duration) = "timeout" => d
    [<Inline>]
    static member timeout (t: MUI.Auto) = "timeout" => t
    [<Inline>]
    static member title (e: React.Element) = "title" => e
    [<Inline>]
    static member titleAccess (s: string) = "titleAccess" => s
    [<Inline>]
    static member titlePosition (p: MUI.VPosition) = "titlePosition" => p
    [<Inline>]
    static member titleTypographyProps (o: obj) = "titleTypographyProps" => o
    [<Inline>]
    static member touchEvent (b: bool) = "touchEvent" => b
    [<Inline>]
    static member touchEvent (e: MUI.TouchEvent) = "touchEvent" => e
    [<Inline>]
    static member transformOrigin (o: MUI.Origin) = "transformOrigin" => o
    [<Inline>]
    static member transition (b: bool) = "transition" => b
    [<Inline>]
    static member TransitionComponent (tag: string) = "TransitionComponent" => tag
    [<Inline; Macro(typeof<AttrMacros.MUIComponentAttr>)>]
    static member TransitionComponent (ctor: seq<string * obj> -> seq<React.Element> -> React.Element) = "TransitionComponent" => ctor
    [<Inline; Macro(typeof<React.Macros.Make>)>]
    static member TransitionComponent<'Props, 'State> (ctor: 'Props -> React.Component<'Props, 'State>) = "TransitionComponent" => ctor
    [<Inline>]
    static member transitionDuration (enterAndExit: int) = "transitionDuration" => enterAndExit
    [<Inline>]
    static member transitionDuration (d: MUI.Duration) = "transitionDuration" => d
    [<Inline>]
    static member TransitionProps (o: obj) = "TransitionProps" => o
    [<Inline>]
    static member valueBuffer (i: int) = "valueBuffer" => i
    [<Inline>]
    static member variant (v: MUI.ButtonVariant) = "variant" => v
    [<Inline>]
    static member variant (v: MUI.ProgressVariant) = "variant" => v
    [<Inline>]
    static member variant (v: MUI.DrawerVariant) = "variant" => v
    [<Inline>]
    static member variant (v: MUI.MobileStepperVariant) = "variant" => v
    [<Inline>]
    static member variant (v: MUI.TableCellVariant) = "variant" => v
    [<Inline>]
    static member variant (v: MUI.ToolbarVariant) = "variant" => v
    [<Inline>]
    static member variant (v: MUI.TypographyVariant) = "variant" => v
    [<Inline>]
    static member viewBox (s: string) = "viewBox" => s
    [<Inline>]
    static member wrap (w: MUI.Wrap) = "wrap" => w
    [<Inline>]
    static member xl (b: bool) = "xl" => b
    [<Inline>]
    static member xl (i: int) = "xl" => i
    [<Inline>]
    static member xl (a: MUI.Auto) = "xl" => a
    [<Inline>]
    static member xlDown (b: bool) = "xlDown" => b
    [<Inline>]
    static member xlUp (b: bool) = "xlUp" => b
    [<Inline>]
    static member xs (b: bool) = "xs" => b
    [<Inline>]
    static member xs (i: int) = "xs" => i
    [<Inline>]
    static member xs (a: MUI.Auto) = "xs" => a
    [<Inline>]
    static member xsDown (b: bool) = "xsDown" => b
    [<Inline>]
    static member xsUp (b: bool) = "xsUp" => b
    [<Inline>]
    static member zeroMinWidth (b: bool) = "zeroMinWidth" => b

type on =
    [<Inline>]
    static member backdropClick (f: SyntheticEvent -> unit) = "onBackdropClick" => f
    [<Inline>]
    static member change (f: SyntheticEvent * bool -> unit) = "onChange" => FuncWithArgs(f)
    [<Inline>]
    static member change (f: SyntheticEvent * int -> unit) = "onChange" => FuncWithArgs(f)
    [<Inline>]
    static member changePage (f: SyntheticEvent * int -> unit) = "onChangePage" => FuncWithArgs(f)
    [<Inline>]
    static member changeRowsPerPage (f: SyntheticEvent -> unit) = "onChangeRowsPerPage" => f
    [<Inline>]
    static member close (f: SyntheticEvent -> unit) = "onClose" => f
    [<Inline>]
    static member delete (f: SyntheticEvent -> unit) = "onDelete" => f
    [<Inline>]
    static member enter (f: SyntheticEvent -> unit) = "onEnter" => f
    [<Inline>]
    static member entered (f: SyntheticEvent -> unit) = "onEntered" => f
    [<Inline>]
    static member entering (f: SyntheticEvent -> unit) = "onEntering" => f
    [<Inline>]
    static member escapeKeyDown (f: SyntheticEvent -> unit) = "onEscapeKeyDown" => f
    [<Inline>]
    static member exit (f: SyntheticEvent -> unit) = "onExit" => f
    [<Inline>]
    static member exited (f: SyntheticEvent -> unit) = "onExited" => f
    [<Inline>]
    static member exiting (f: SyntheticEvent -> unit) = "onExiting" => f
    [<Inline>]
    static member focusVisible (f: SyntheticEvent -> unit) = "onFocusVisible" => f
    [<Inline>]
    static member ``open`` (f: SyntheticEvent -> unit) = "onOpen" => f
    [<Inline>]
    static member rendered (f: SyntheticEvent -> unit) = "onRendered" => f
