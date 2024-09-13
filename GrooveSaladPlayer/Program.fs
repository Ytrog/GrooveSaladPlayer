// For more information see https://aka.ms/fsharp-console-apps
open NAudio.MediaFoundation
open NAudio.Wasapi
open NAudio.Wave
open System.Threading
open System


let url = "https://ice1.somafm.com/groovesalad-128-aac"

printfn "Starting Groove Salad Playback"

let start () =
    use mf = new MediaFoundationReader(url)
    use wo = new WasapiOut()

    wo.Init(mf)
    wo.Play()
    
    printfn "Press any key to stop"
    Console.ReadKey() |> ignore

start()


