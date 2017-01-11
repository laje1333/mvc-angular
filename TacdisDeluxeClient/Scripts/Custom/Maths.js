var Maths = {};
Maths.Datastructures = {};
Maths.Arrays = {};
Maths.Objects = {};
Maths.Random = {};

//Arrays
Maths.Arrays.BinarySearch = function (A, V, Key) {
    if (Key != null) {
        var L = 0;
        var R = (A.length - 1);
        while (L <= R) {
            var M = Math.floor((L + R) / 2);
            if ((A[M])[Key] < V) {
                L = (M + 1);
            } else if ((A[M])[Key] == V) {
                return M;
            } else {
                R = (M - 1);
            }
        }
    } else {
        var L = 0;
        var R = (A.length - 1);
        while (L <= R) {
            var M = Math.floor((L + R) / 2);
            if ((A[M]) < V) {
                L = (M + 1);
            } else if ((A[M]) == V) {
                return M;
            } else {
                R = (M - 1);
            }
        }
    }
}

//Datastructures
Maths.Datastructures.HashMap = function () {
    this.map = {};

    this.add = function (objA, objB) {
        if (objA.hashKey == undefined) {
            objA.hashKey = new Maths.Random.String(15).hash;
        }
        this.map[objA.hashKey] = objB;
    }

    this.get = function (obj) {
        return this.map[obj.hashKey];
    }

    this.getEnumerable = function () {
        return this.map;
    }

    this.clear = function () {
        this.map = {};
    }
    
}
Maths.Datastructures.BinaryTree = function (Key) {

    var Node = function (val, lft, rgt) {
        this.value = val[Key];
        this.left = lft;
        this.right = rgt;
    }
    this.root = null;

    this.insert = function (val) {
        var tempNode = new Node(val , null, null);
        var current  = new Node(null, null, null);
        var parent   = new Node(null, null, null);

        if (this.root == null) {
            this.root = tempNode;
            return;
        } else {
            current = this.root;
            parent = null;

            while (true) {
                parent = current;
                if(val < parent.value) {
                    current = current.left;                
                    
                    if(current == null) {
                        parent.left = new Node(val, null,null);
                        return;
                    }
                }else {
                    current = current.right;
                    if(current == null) {
                        parent.right = new Node(val, null, null);
                        return;
                    }
                }
            }
        }

    }

    this.search = function (val) {
        var currentNode = this.root;

        while (currentNode.value != val) {

            if (currentNode.value > val) {
                currentNode = currentNode.left;
            } else {
                currentNode = currentNode.right;
            }
            if (currentNode == null) {
                return null;
            }
        }
        return currentNode;
    }
}
Maths.Datastructures.BinaryHeap = function (Key) {

    this.heap = [];
    this.key = Key;

    var Node = function (obj, par) {
        this.object = obj;
        if (Key != null) {
            var tempArr = Key.split(".");
            var result = obj[tempArr[0]];
            for (i = 1; i < tempArr.length; i++) {
                result = result[tempArr[i]];
            }
            this.compare = result;
        } else {
            this.compare = this.object;
        }
        this.parent = par;
    }

    this.insert = function (object) {
        var heapSize = this.heap.length;
        if (heapSize <= 0) {
            this.heap.push(new Node(object, null));
        } else {
            var indexAfterInsert = heapSize + 1;
            var parentIndex = Math.floor((indexAfterInsert - 1) / 2);
            this.heap.push(new Node(object, this.heap[parentIndex]));
        }
        if (heapSize > 0) {
            this.siftUp();
        }
    }

    this.getCollection = function () {
        return this.heap;
    }

    this.count = function () {
        return this.heap.length;
    }

    this.siftUp = function () {
        var currentIndex = this.heap.length-1;
        var parentIndex = Math.floor((currentIndex - 1) / 2);

        while (true) {
            if (this.heap[currentIndex].compare > this.heap[parentIndex].compare) {
                var parent = this.heap[parentIndex];
                var current = this.heap[currentIndex];
                this.heap[currentIndex] = parent;
                this.heap[parentIndex] = current;
                currentIndex = parentIndex;
                parentIndex = Math.floor((currentIndex - 1) / 2);
            } else {
                return;
            }
            if (currentIndex <= 0) {
                return;
            }
        }
    }

    this.getMaximum = function () {
        var leaf = this.heap.pop();
        var result = this.heap[0];
        this.heap[0] = leaf;
        var currentIndex = 0;
        while (true) {
            if (this.heap[2 * currentIndex + 1] != null || this.heap[2 * currentIndex + 2] != null) {
                var leftVal = null;
                var rightVal = null;
                if (this.heap.length > 2 * currentIndex + 1) {
                    leftVal = this.heap[2 * currentIndex + 1].compare;
                }
                if (this.heap.length > 2 * currentIndex + 2) {
                    rightVal = this.heap[2 * currentIndex + 2].compare;
                }
                var swapWithLeaf;
                if (leftVal > rightVal && leaf.compare < leftVal && leftVal != null) {
                    swapWithLeaf = this.heap[2 * currentIndex + 1];
                    var tempLeaf = leaf;
                    this.heap[currentIndex] = swapWithLeaf;
                    this.heap[2 * currentIndex + 1] = tempLeaf;
                    currentIndex = 2 * currentIndex + 1;
                } else if (leftVal < rightVal && leaf.compare < rightVal && rightVal != null) {
                    swapWithLeaf = this.heap[2 * currentIndex + 2];
                    var tempLeaf = leaf;
                    this.heap[currentIndex] = swapWithLeaf;
                    this.heap[2 * currentIndex + 2] = tempLeaf;
                    currentIndex = 2 * currentIndex + 2;
                } else {
                    return result.object;
                }
            } else {
                return result.object;
            }
        }
    }
}

//Random
Maths.Random.String = function(length){
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < length; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));
    return {hash : text};
}

