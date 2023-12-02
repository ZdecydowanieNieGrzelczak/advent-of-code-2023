namespace Library

open System.IO

module shared =
    let getFilePath filename = 

    let baseDirectory = __SOURCE_DIRECTORY__
    let baseDirectory' = Directory.GetParent(baseDirectory)
    let filePath = "Library/data/input1.txt"
    let fullPath = Path.Combine(baseDirectory'.FullName, filePath)