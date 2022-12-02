module aoc.Downloader

open System.Net
open System.Runtime.CompilerServices
open FSharp.Data
open FSharp.Data.HttpRequestHeaders

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

let advent_cookie = "ADVENT_SESSION"

let internal adventUrl (year: int) (day: int) : string =
    $"https://adventofcode.com/{year}/day/{day}/input"

let internal cookies cookieName : string option =
    try
        match System.Environment.GetEnvironmentVariable cookieName with
        | null -> None
        | cookie -> Some cookie
    with _ ->
        None

let internal downloadUrlWithCookie cookie url =
    Http.RequestString(url,
                       cookies = [ "session", cookie ],
                       silentHttpErrors = false,
                       headers = [ Accept HttpContentTypes.Any; UserAgent "https://github.com/Vest/aoc-fs/" ])

let downloadInput year day : string option =
    match cookies advent_cookie with
    | Some cookie ->
        try
            adventUrl year day |> downloadUrlWithCookie cookie |> Some
        with :? WebException as exn ->
            eprintfn $"Couldn't download the input: {exn.Message}"
            None
    | None ->
        eprintfn $"No session was provided, please use environment variable {advent_cookie}"
        None
