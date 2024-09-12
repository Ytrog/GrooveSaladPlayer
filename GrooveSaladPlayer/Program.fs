// For more information see https://aka.ms/fsharp-console-apps
open NAudio.MediaFoundation
open NAudio.Wasapi
open NAudio.Wave
open System.Threading


let url = "https://ice1.somafm.com/groovesalad-128-aac"

printfn "Starting Groove Salad Playback"

let start () =
    use mf = new MediaFoundationReader(url)
    use wo = new WasapiOut()

    wo.Init(mf)
    wo.Play()

    while true do
        Thread.Sleep 1000


start()


