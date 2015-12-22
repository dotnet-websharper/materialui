#load "tools/includes.fsx"

open IntelliFactory.Build

let bt =
    BuildTool().PackageId("Zafir.MaterialUI")
        .VersionFrom("Zafir")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun x -> x.Net40)

let library =
    bt.Zafir.Library("WebSharper.MaterialUI")
        .SourcesFromProject()
        .References(fun ref ->
            [
                ref.NuGet("Zafir.React").Latest(true).ForceFoundVersion().Reference()
            ])
        .Embed(
            [
                "material-ui.min.js"
            ])

let tests =
    bt.Zafir.BundleWebsite("WebSharper.MaterialUI.Tests")
        .SourcesFromProject()
        .References(fun ref -> 
            [
                ref.NuGet("Zafir.React").Latest(true).Reference()
                ref.Project library
            ])

bt.Solution [
    library
    tests

    bt.NuGet.CreatePackage()
        .Configure(fun configuration ->
            { configuration with
                Title = Some "Zafir.MaterialUI"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://bitbucket.org/intellifactory/websharper.materialui"
                Description = "WebSharper bindings for Material UI"
                Authors = [ "IntelliFactory" ]
                RequiresLicenseAcceptance = true })
        .Add(library)
]
|> bt.Dispatch
