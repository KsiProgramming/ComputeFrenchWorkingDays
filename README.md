# Compute French Working Days

The `ComputeFrenchWorkingDays` library is a .NET utility that allows you to calculate working days in France, considering fixed holidays and variable holidays like Easter Monday, Ascension, and Pentecost.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Requirements](#requirements)
- [Usage](#usage)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Introduction

In France, certain holidays are fixed and occur on the same date every year. Additionally, there are variable holidays based on the Easter date, such as Easter Monday, Ascension, and Pentecost. The `ComputeFrenchWorkingDays` library provides functionalities to compute working days by considering these fixed and variable holidays.

## Features

- Calculate working days by excluding weekends (Saturdays and Sundays).
- Account for fixed holidays, such as New Year's Day, Labor Day, Victory in Europe Day, Bastille Day, Assumption of Mary, All Saints' Day, Armistice Day, and Christmas Day.
- Consider variable holidays based on Easter, such as Easter Monday, Ascension, and Pentecost.
- Handle leap years and ensure accurate calculations for any year after 1583.

## Requirements

- .NET Core 3.1 or higher.

## Usage

To use the `ComputeFrenchWorkingDays` library in your project, first, clone this repository to your local machine.

```bash
git clone https://github.com/KsiProgramming/ComputeFrenchWorkingDays.git
```

Next, add the ComputeFrenchWorkingDays project as a reference to your solution.

```bash
cd ComputeFrenchWorkingDays
dotnet add reference path/to/your/project.csproj
```

Now you can use the ComputeFrenchWorkingDays library in your project.

```csharp
using ComputeFrenchWorkingDays;

// ...

// Calculate working days
DateTime startDate = new DateTime(2023, 7, 31);
int workingDaysToAdd = 3;
DateTime resultDate = startDate.AddFrenchWorkingDays(workingDaysToAdd);

Console.WriteLine($"Result: {resultDate:yyyy-MM-dd}");
```

## Examples

Here are some examples of how to use the ComputeFrenchWorkingDays library:

```csharp
using ComputeFrenchWorkingDays;

// Calculate working days for a given DateTime
DateTime startDate = new DateTime(2023, 7, 31);
int workingDaysToAdd = 3;
DateTime resultDate = startDate.AddFrenchWorkingDays(workingDaysToAdd);

Console.WriteLine($"Result: {resultDate:yyyy-MM-dd}");
// Output: Result: 2023-08-03

// Calculate working days for a given DateOnly
DateOnly startDateOnly = new DateOnly(2023, 7, 31);
DateOnly resultDateOnly = startDateOnly.AddFrenchWorkingDays(5);

Console.WriteLine($"Result: {resultDateOnly:yyyy-MM-dd}");
// Output: Result: 2023-08-07
```

## Contributing

Contributions to the ComputeFrenchWorkingDays library are welcome! If you find a bug, have an idea for an improvement, or want to add a new feature, please open an issue or submit a pull request.

Before contributing, please review the [Contribution Guidelines](CONTRIBUTING.md).

## License

The `ComputeFrenchWorkingDays` library is licensed under the [MIT License](LICENSE).

---

Thank you for using `ComputeFrenchWorkingDays`! We hope this library simplifies your working days calculation needs in France. If you have any questions or need further assistance, feel free to reach out to us. Happy coding!

