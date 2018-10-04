// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
namespace WebSharper.MaterialUI.Tests

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings
open WebSharper.React
open WebSharper.React.Html
open WebSharper.MaterialUI

[<JavaScript>]
module Client =

    type Task =
        {
            Name  : string
            State : bool
        }

        static member Toggle task _ =
            { task with
                State = not task.State }

    type State =
        {
            Input : string
            Tasks : Task list
        }

        static member Default =
            {
                Input = ""
                Tasks =
                    [
                        { Name = "buy milk"; State = false }
                    ]
            }

    type Main(props) as this =
        inherit React.Component<MUI.Styles, State>(props)

        do this.SetInitialState State.Default

        member private this.SetInput(ev: SyntheticEvent) =
            this.SetState { this.State with Input = ev.Target?value }

        member private this.AddTask() =
            if this.State.Input.Length > 0 && not (List.exists (fun task -> task.Name = this.State.Input) this.State.Tasks) then
                { this.State with
                    Input = ""
                    Tasks =
                        { Name = this.State.Input; State = false } :: this.State.Tasks }
                |> this.SetState

        member private this.ClearCompleted() =
            { this.State with
                Tasks =
                    this.State.Tasks
                    |> List.filter (fun task -> not task.State) }
            |> this.SetState

        member private this.ToggleTask(task) =
            { this.State with
                Tasks =
                    this.State.Tasks
                    |> List.map (fun x ->
                        if x.Name = task.Name then
                            { task with State = not task.State }
                        else
                            x
                    ) }
            |> this.SetState

        override this.Render() =
            MUI.Paper [attr.className this.Props.Classes.["root"]] [
                MUI.Button [
                    attr.variant MUI.ButtonVariant.Contained
                    attr.fullWidth true
                    attr.color MUI.Color.Secondary
                    on.click (fun _ -> this.ClearCompleted())
                ] [text "Clear completed tasks"]
                MUI.List [
                    attr.className this.Props.Classes.["list"]
                    attr.subheader (MUI.ListSubheader [] [text "MyTasks"])
                ] [
                    for task in this.State.Tasks ->
                        MUI.ListItem [
                            attr.``component`` MUI.ButtonBase
                            attr.button true
                            on.click (fun _ -> this.ToggleTask(task))
                        ] [
                            MUI.Checkbox ["checked" => task.State] []
                            MUI.ListItemText [] [text task.Name]
                        ]
                ]
                
                MUI.TextField [
                    attr.fullWidth true
                    attr.margin MUI.Margin.Normal
                    attr.autoFocus true
                    attr.value this.State.Input
                    attr.placeholder "What needs to be done?"
                    on.change this.SetInput
                ] []
                MUI.Button [
                    attr.variant MUI.ButtonVariant.Contained
                    attr.fullWidth true
                    attr.color MUI.Color.Primary
                    on.click (fun _ -> this.AddTask())
                ] [text "Add"]
            ]

    let MyTheme =
        MUI.Theme(
            Palette = MUI.Palette(
                Primary = MUI.Colors.Green,
                Type = MUI.Dark
            )
        )

    let MyStyles (theme: MUI.Theme) =
        New [
            "root" => New [
                "marginTop" => theme.Spacing.Unit
                "marginBottom" => theme.Spacing.Unit
                "marginLeft" => theme.Spacing.Unit
                "marginRight" => theme.Spacing.Unit
                "flex" => 1
                "display" => "flex"
                "flexDirection" => "column"
            ]
            "list" => New [
                "flex" => 1
                "overflowY" => "auto"
            ]
        ]

    [<SPAEntryPoint>]
    let Main() =
        let theme = MUI.CreateTheme MyTheme
        MUI.ThemeProvider theme [
            MUI.CssBaseline()
            MUI.WithStyles MyStyles Main
        ]
        |> React.Mount JS.Document.Body
