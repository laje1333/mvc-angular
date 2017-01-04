var Maths = {};

Maths.binarySearch = function(A, V) {
    var L = 0;
    var R = (A.length - 1);
    while (L < R) {
        var M = Math.floor((L + R) / 2);
        if (A[M] < V) {
            L = (M + 1);
        } else if (A[M] == V) {
            return M;
        } else {
            R = (M - 1);
        }
    }
}