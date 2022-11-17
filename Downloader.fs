module aoc.Downloader

open System.Runtime.CompilerServices
open FSharp.Data

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

let advent_cookie = "ADVENT_SESSION"
let internal adventUrl (year: int) (day: int) : string = $"https://adventofcode.com/{year}/day/{day}/input"
let internal cookies cookieName: string option =
    try
        match System.Environment.GetEnvironmentVariable cookieName with
        | null -> None
        | cookie -> Some cookie
    with _ ->
        None

let internal downloadUrlWithCookie cookie url =
    Http.RequestString(url, cookies = ["session", cookie], silentHttpErrors = true)

let downloadInput year day : string option =
    match cookies advent_cookie with
    | Some cookie -> adventUrl year day |> downloadUrlWithCookie cookie |> Some
    | None ->
        printfn $"No session was provided, please use environment variable {advent_cookie}"
        None
