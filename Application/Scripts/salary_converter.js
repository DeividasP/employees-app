var PRECISION = 2;

var MINIMUM_SALARY = 380;
var TAX_EXEMPT_INCOME_BASE = 310;

var INCOME_TAX = 0.15;
var SOCIAL_SECURITY_TAX = 0.03;
var HEALTH_INSURANCE_TAX = 0.06;

function toGrossSalary(netSalary, precision) {
    var grossSalary = (netSalary <= deductTaxes(MINIMUM_SALARY) + INCOME_TAX * TAX_EXEMPT_INCOME_BASE)
        ? (netSalary <= deductInsuranceTaxes(TAX_EXEMPT_INCOME_BASE))
            ? netSalary / deductInsuranceTaxes(1)
            : (netSalary - INCOME_TAX * TAX_EXEMPT_INCOME_BASE) / deductTaxes(1)
        : (netSalary <= (deductInsuranceTaxes(1) - INCOME_TAX * 1.5) * (1 / 0.5 * TAX_EXEMPT_INCOME_BASE + MINIMUM_SALARY) + INCOME_TAX * (TAX_EXEMPT_INCOME_BASE + 0.5 * MINIMUM_SALARY + 0))
            ? (1.5 * netSalary / deductInsuranceTaxes(1) - TAX_EXEMPT_INCOME_BASE - 0.5 * MINIMUM_SALARY <= 0)
                ? netSalary / deductInsuranceTaxes(1)
                : (netSalary - INCOME_TAX * TAX_EXEMPT_INCOME_BASE - INCOME_TAX * 0.5 * MINIMUM_SALARY) / (deductInsuranceTaxes(1) - INCOME_TAX * 1.5)
            : (netSalary <= 0)
                ? netSalary / deductInsuranceTaxes(1)
                : netSalary / deductTaxes(1);

    return grossSalary.toFixed(precision);
}

function deductInsuranceTaxes(value) {
    return value * (1 - SOCIAL_SECURITY_TAX - HEALTH_INSURANCE_TAX);
}

function deductTaxes(value) {
    return value * (1 - INCOME_TAX - SOCIAL_SECURITY_TAX - HEALTH_INSURANCE_TAX);
}

$(document).ready(function () {
    $("#Salary").on("input", function () {
        var netSalary = parseFloat($("#Salary").val());
        $("#GrossSalary").val(toGrossSalary(netSalary, PRECISION));
    });
});