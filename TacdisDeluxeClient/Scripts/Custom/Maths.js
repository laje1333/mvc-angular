var Maths = {};

/*
    Binary search:
        Given an array A and a value V, finds the index of V.

    HashMap:
        Create new instance:
            - var x = new Maths.HashMap();
        <Key, Value>, where Key is of type string.

        Methods:
            -elementExists
            -getLength
            -clear
            -isEmpty
            -getCollection
            -removeElement
            -addElement
            -getElement

    BinaryTree:
        Create new instance:
            - var x = new Maths.BinaryTree();
        The left sub-tree of a node has a value less than or equal to its parent node's key.
        The right sub-tree of a node has a value greater than to its parent node's key.

        Methods:
            -insert
            -search
*/



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



