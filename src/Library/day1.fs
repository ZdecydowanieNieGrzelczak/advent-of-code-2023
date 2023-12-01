namespace Library
module day1 =
    let inline charToInt (c: char) = int c - int '0'

    let rec firstNumericChar = function
        | [] -> raise <| MatchFailureException("Cannot match", 1, 1)
        | head :: tail when System.Char.IsDigit head -> head |> charToInt
        | head :: tail -> firstNumericChar tail
        

    let stringToCalibration (inputString: string) =
        let first = Seq.toList inputString |> firstNumericChar
        let last = Seq.toList inputString |> List.rev |> firstNumericChar
        first * 10 + last

    open System.IO
    printfn "Reading files for day 1!"
    let baseDirectory = __SOURCE_DIRECTORY__
    let baseDirectory' = Directory.GetParent(baseDirectory)
    let filePath = "Library/data/input1.txt"
    let fullPath = Path.Combine(baseDirectory'.FullName, filePath)
    let solve: string =
        let sum = 0
        let lines = System.IO.File.ReadLines(fullPath)
        let sum = Seq.map (fun x -> stringToCalibration x) lines |> Seq.sum
        printfn "Files read, solving"

        sprintf "%i" sum
