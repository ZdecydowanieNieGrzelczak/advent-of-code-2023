namespace Library
module day2 =
    let inline charToInt (c: char) = int c - int '0'
    let replaceString (text: string) (newValue: string) (old: string) = 
        text.Replace(old, newValue)
    let wordToDigit (text: string) =
        let replacements = [ ("one", "o1e");
            ("two", "t2o");
            ("three", "t3e");
            ("four", "f4r");
            ("five", "f5e");
            ("six", "s6x");
            ("seven", "s7n");
            ("eight", "e8t");
            ("nine", "n9e")
            ]
        let rec replaceAllOccurences text = function
            | (word, value)::tail -> replaceAllOccurences (replaceString text value word) tail
            | [] -> text

        let rec matchText current = function
            | head::tail -> matchText (replaceAllOccurences (current + string head) replacements) tail
            | [] -> current 

        // matchText "" (text |> List.ofSeq)
        replaceAllOccurences text replacements

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
        // Seq.iter (fun line -> printfn "%s" (wordToDigit line)) lines
        let sum = Seq.map (fun line -> stringToCalibration (wordToDigit line)) lines |> Seq.sum
        printfn "Files read, solving"

        sprintf "%i" sum
