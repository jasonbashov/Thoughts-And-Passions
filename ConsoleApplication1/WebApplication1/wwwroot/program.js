var validVals = ["1234", "12.3", "12.31", "1.11", "0.4", "0", ".1"];
var invalidVals = ["12.314","3.14152", "1.", "123456.78901", "AAAAA", "a3.123"];


function runTests(re) {
    console.group(re);
    testItems(re, validVals, true);
    testItems(re, invalidVals, false);
    console.groupEnd(re);
}

function testItems(re, arr, expected) {
    for (var i = 0; i < arr.length; i++) {
        var result = re.test(arr[i]);
        var out = expected === result ? "info" : "error";
        console[out](arr[i], "\t\t\t\t", "Expected " + expected, "\t", "Result " + result);
    }
}

runTests(/^(\d+)?(?:\.\d{1,2})?$/);
