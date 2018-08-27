namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator
open WebSharper.React.Bindings

module Res =

    let Roboto =
        Resource "Roboto" "https://fonts.googleapis.com/css?family=Roboto:300,400,500"

    let MaterialUI =
        Resource "MaterialUI" "https://unpkg.com/@material-ui/core/umd/material-ui.production.min.js"
        |> Requires [Roboto]
        |> AssemblyWide

module Definition =

    let configOf (c: CodeModel.Class) =
        c.NestedClasses
        |> List.find (fun c -> c.Name = "Config")

    let cls name inherits config =
        let config =
            ("classes", T<Object<string>>) ::
            ("children", Type.ArrayOf T<React.Element>) ::
            config
        let Config = Pattern.Config "Config" { Required = []; Optional = config }
        let Config =
            match inherits with
            | None -> Config
            | Some c -> Config |=> Inherits (configOf c)
        Class name
        |=> Inherits T<React.Component<_,_>>.[Config, T<unit>]
        |=> Nested [Config]
        |+> Static [
            Constructor Config
            |> WithInline ("new $global['material-ui']."+name+"($0)")
        ]

    let Color =
        Pattern.EnumStrings "Color"
            ["inherit"; "primary"; "secondary"; "default"]

    let Position =
        Pattern.EnumStrings "Position"
            ["fixed"; "absolute"; "sticky"; "static"]

    let TransitionDuration =
        Pattern.Config "TransitionDuration" {
            Required = []
            Optional =
                [
                    "enter", T<int>
                    "exit", T<int>
                ]
        }
        |+> Static [
            "symmetric" => T<int> ^-> TSelf
            |> WithInline "$0"
            |> WithComment "Use the same duration for enter and exit."
        ]

    let Size =
        Pattern.EnumStrings "Size"
            ["small"; "medium"; "large"]

    let Margin =
        Pattern.EnumStrings "Margin"
            ["none"; "dense"; "normal"]

    let Paper =
        cls "Paper" None [
            "component", T<obj>
            "elevation", T<int>
            "square", T<bool>
        ]

    let AppBar =
        cls "AppBar" (Some Paper) [
            "color", Color.Type
            "position", Position.Type
        ]

    let Avatar =
        cls "Avatar" None [
            "alt", T<string>
            "component", T<obj>
            "imgProps", T<Object<string>>
            "sizes", T<string>
            "src", T<string>
            "srcSet", T<string>
        ]

    let Backdrop =
        cls "Backdrop" None [
            "invisible", T<bool>
            "open", T<bool>
            "transitionDuration", TransitionDuration.Type
        ]

    let Badge =
        cls "Badge" None [
            "badgeContent", T<React.Element>
            "color", Color.Type
            "component", T<obj>
        ]

    let BottomNavigation =
        cls "BottomNavigation" None [
            "onChange", (T<Dom.Event> * T<obj> ^-> T<unit>)
            "showLabels", T<bool>
            "value", T<obj>
        ]

    let TouchRipple =
        cls "TouchRipple" None [
            "center", T<bool>
        ]

    let ButtonBase =
        cls "ButtonBase" None [
            "action", (T<obj> ^-> T<unit>)
            "buttonRef", T<React.Ref>
            "centerRipple", T<bool>
            "component", T<obj>
            "disabled", T<bool>
            "disableRipple", T<bool>
            "disableTouchRipple", T<bool>
            "focusRipple", T<bool>
            "focusVisibleClassName", T<string>
            "onFocusVisible", (T<Dom.Event> * T<obj> ^-> T<unit>)
            "TouchRippleProps", (configOf TouchRipple).Type
            "type", T<string>
        ]

    let BottomNavigationAction =
        cls "BottomNavigationAction" (Some BottomNavigation) [
            "icon", T<React.Element>
            "label", T<React.Element>
            "showLabel", T<bool>
            "value", T<obj>
        ]

    let ButtonVariant =
        Pattern.EnumStrings "Variant"
            ["text"; "flat"; "outlined"; "contained"; "raised"; "fab"; "extendedFab"]

    let Button =
        cls "Button" (Some ButtonBase) [
            "color", Color.Type
            "disableFocusRipple", T<bool>
            "fullWidth", T<bool>
            "href", T<string>
            "mini", T<bool>
            "size", Size.Type
            "variant", ButtonVariant.Type
        ]
        |=> Nested [ButtonVariant]

    let Card =
        cls "Card" (Some Paper) [
            "raised", T<bool>
        ]

    let CardActions =
        cls "CardActions" None [
            "disableActionSpacing", T<bool>
        ]

    let CardContent =
        cls "CardContent" None [
            "component", T<obj>
        ]

    let CardHeader =
        cls "CardHeader" None [
            "action", T<React.Element>
            "avatar", T<React.Element>
            "component", T<obj>
            "disableTypography", T<bool>
            "subheader", T<React.Element>
            "subheaderTypographyProps", T<obj>
            "title", T<React.Element>
            "titleTypographyProps", T<obj>
        ]

    let CardMedia =
        cls "CardMedia" None [
            "component", T<React.Element>
            "image", T<string>
            "src", T<string>
        ]

    let Checkbox =
        cls "Checkbox" None [
            "checked", T<bool>
            "checkedIcon", T<React.Element>
            "color", Color.Type
            "disabled", T<bool>
            "disableRipple", T<bool>
            "icon", T<React.Element>
            "id", T<string>
            "indeterminate", T<bool>
            "indeterminateIcon", T<React.Element>
            "inputProps", T<obj>
            "inputRef", T<React.Ref>
            "onChange", (T<Dom.Event> * T<obj> ^-> T<unit>)
            "type", T<string>
            "value", T<string>
        ]

    let FormControl =
        cls "FormControl" None [
            "component", T<React.Element>
            "disabled", T<bool>
            "error", T<bool>
            "fullWidth", T<bool>
            "margin", Margin.Type
            "required", T<bool>
        ]

    let TextField =
        cls "TextField" None [
            "autoComplete", T<string>
            "autoFocus", T<string>
            "defaultValue", T<string>
            "FormHelperTextProps", T<obj>
            "helperText", T<React.Element>
            "id", T<string>
            "InputLabelProps", T<obj>
            "InputProps", T<obj>
            // "inputProps", T<obj> //TODO: This is embarrassing... :/
            "inputRef", T<React.Ref>
            "label", T<React.Element>
            "margin", Margin.Type
            "multiline", T<bool>
            "name", T<string>
            "onChange", (T<Dom.Event> * T<obj> ^-> T<unit>)
            "placeholder", T<string>
            "required", T<bool>
            "rows", T<int>
            "rowsMax", T<int>
            "select", T<bool>
            "SelectProps", T<obj>
            "type", T<string>
            "value", T<obj>
        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.MaterialUI" [
                Color
                Position
                TransitionDuration
                Size
                Margin
                Paper
                AppBar
                Avatar
                Backdrop
                Badge
                BottomNavigation
                TouchRipple
                ButtonBase
                BottomNavigationAction
                Button
                Card
                CardActions
                CardContent
                CardHeader
                CardMedia
                Checkbox
                FormControl
                TextField
            ]
            Namespace "WebSharper.MaterialUI.Resources" [
                Res.Roboto
                Res.MaterialUI
            ]
        ]

[<Sealed>]
type Extension() =
    interface IExtension with
        member x.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
