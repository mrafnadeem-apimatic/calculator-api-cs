# Simple Calculator

```csharp
SimpleCalculatorController simpleCalculatorController = client.SimpleCalculatorController;
```

## Class Name

`SimpleCalculatorController`


# Get Calculate

Calculates the expression using the specified operation.

```csharp
GetCalculateAsync(
    Models.GetCalculateInput input)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | [`Models.OperationTypeEnum`](../../doc/models/operation-type-enum.md) | Template, Required | The operator to apply on the variables |
| `x` | `double` | Query, Required | The LHS value |
| `y` | `double` | Query, Required | The RHS value<br>**Constraints**: *Total Digits*: `4`, *Fraction Digits*: `1` |
| `stringparam` | `string` | Query, Optional | **Constraints**: *Minimum Length*: `0`, *Maximum Length*: `25`, *Pattern*: `[A-Z]+` |
| `dateparam` | `DateTime?` | Query, Optional | - |
| `numparam` | `int?` | Query, Optional | **Constraints**: `> 5`, `< 18`, *Multiple Of*: `3`, *Total Digits*: `2`, *Fraction Digits*: `1`, *Pattern*: `4` |
| `objparam` | `object` | Query, Optional | - |

## Response Type

`Task<double>`

## Example Usage

```csharp
var getCalculateInput = new GetCalculateInput();

getCalculateInput.Operation = OperationTypeEnum.MULTIPLY;
getCalculateInput.X = 222.14;
getCalculateInput.Y = 165.14;

try
{
    double? result = await simpleCalculatorController.GetCalculateAsync(getCalculateInput);
}
catch (ApiException e){};
```

