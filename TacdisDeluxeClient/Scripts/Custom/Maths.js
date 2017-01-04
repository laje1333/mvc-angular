var Maths = {};

Maths.BinarySearch = function(A, V) {
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

Maths.HashMap = function () {
    this.map = {};
    this.length = 0;

    this.elementExists = function (key) {
        return key in this.map;
    }

    this.getElement = function (key) {
        if (this.elementExists(key)) {
            return this.map[key];
        }
    }

    this.addElement = function (key, value) {
        if (!this.elementExists(key)) {
            this.map[key] = value;
            this.length += 1;
        }
    }

    this.removeElement = function (key) {
        if (this.elementExists(key)) {
            delete this.map[key];
            this.length -= 1;
        }
    }

    this.getCollection = function () {
        return this.map;
    }

    this.isEmpty = function () {
        return (length <= 0);
    }

    this.clear = function () {
        this.map = {};
    }

    this.getLength = function () {
        return length;
    }
}

Maths.BinaryTree = function () {

    var Node = function (val, lft, rgt) {
        this.value = val;
        this.left = lft;
        this.right = rgt;
    }

    this.nodes = [];

    this.insert = function (val) {
        var tempNode = new Node(val , null, null);
        var current  = new Node(null, null, null);
        var parent   = new Node(null, null, null);

        if (this.nodes.length <= 0) {
            this.nodes.push(tempNode);
            return;
        } else {
            current = tempNode;
            parent = null;

            while (true) {
                parent = current;
                if(val < parent.value) {
                    current = current.left;                
                    
                    if(current == null) {
                        parent.left = tempNode;
                        return;
                    }
                }else {
                    current = current.right;
                    if(current == null) {
                        parent.right = tempNode;
                        return;
                    }
                }
            }
        }

    }

}