markdown
# C# Block Code Generator

A visual programming tool for beginners to learn C# by building programs with blocks.  
Generate ready-to-run C# code by dragging and dropping blocks, no prior coding experience required.

## Features
- **Language selection** – English / Russian interface at startup.
- **8 block types**:
  - Variable declaration (`int`, `string`, `bool`, `double`) with optional initial value.
  - Assignment – assign a value to an existing variable.
  - Arithmetic operation (`+`, `-`, `*`, `/`) with choice of left variable and right operand (variable or constant).
  - Console input – store `Console.ReadLine()` result in a variable.
  - Console output – print any expression with `Console.WriteLine()`.
  - `if` condition – insert a conditional statement.
  - `while` loop – add a loop with a condition.
  - Comment – insert a code comment.
- **Smart variable tracking** – after declaring a variable, it becomes available in dropdowns for assignment, arithmetic, and input blocks.
- **Edit blocks** – double‑click any block in the workspace to modify its parameters.
- **Code generation** – produces a complete C# program with `using System;`, namespace, class, and `Main` method.
- **Save to file** – export the generated code as a `.cs` file ready for compilation.

## How to Run
1. Install [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later).
2. Clone or download this repository.
3. Open a terminal in the project folder.
4. Run:
dotnet build
dotnet run

text
5. Choose your language and start building!

## Project Structure
- `MainForm.cs` – contains all the UI logic, block classes, and code generation.
- `c# blue prints.csproj` – project file (created by `dotnet new winforms`).

## Why This Project?
This tool is designed for:
- **Beginners** who want to understand programming logic without worrying about syntax.
- **Teachers** who need an interactive way to introduce C# concepts.
- **Hobbyists** who enjoy visual programming and want to experiment with code generation.

## Future Improvements
- Add nested blocks (blocks inside `if` and `while`).
- Support for more data types and operations.
- Compile and run the generated code directly from the app (using Roslyn).
- Save/load projects.

## License
MIT – free to use, modify, and distribute.

---

Enjoy coding! 😊
