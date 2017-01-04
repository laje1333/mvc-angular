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
        objA.hashKey = new Maths.Random.String(15).hash;
        this.map[objA.hashKey] = objB;
    }

    this.get = function (obj) {
        return this.map[obj.hashKey];
    }

    this.getEnumerable = function () {
        return this.map;
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

//Random
Maths.Random.String = function(length){
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < length; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));
    return {hash : text};
}



