namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript
open WebSharper.React

type Classes =
    {
        root: string
        listItem: string
    }

type Styles =
    {
        classes: Classes
    }

[<Stub>]
type internal MUI' =
    member this.withStyles(styles: obj -> obj) = X<(Styles -> #React.Component<Styles, _>) -> React.Class>

[<AutoOpen>]
module MaterialUI =

    [<Inline "$global['material-ui']">]
    let internal MUI = X<MUI'>

    [<Macro(typeof<React.Macros.Make>, 1); Inline>]
    let WithStyles styles (ctor: Styles -> #React.Component<Styles, _>) : React.Element =
        React.CreateElement(MUI.withStyles styles ctor, null)

// [<Stub; AbstractClass>]
// type Button =
//     inherit React.Component<obj, unit>

//     [<Inline>]
//     static member Make props children =
//         React.Element (JS.Inline "$global['material-ui'].Button") props children

// [<Stub; AbstractClass>]
// type TextField =
//     inherit React.Component<obj, unit>

//     [<Inline>]
//     static member Make props children =
//         React.Element (JS.Inline "$global['material-ui'].TextField") props children

[<assembly: Require(typeof<MaterialUI>)>]
do ()
