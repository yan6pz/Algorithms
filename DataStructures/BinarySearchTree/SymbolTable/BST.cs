
using System;
using System.Collections.Generic;

public class BST<Key, Value> where Key : IComparable
{
    private Node root; // root of BST

    private class Node
    {
        public Key key; // sorted by key
        public Value val; // associated data
        public Node left, right; // left and right subtrees
        public int N; // number of nodes in subtree

        public Node(Key key, Value val, int N)
        {
            this.key = key;
            this.val = val;
            this.N = N;
        }
    }

    // is the symbol table empty?
    public bool isEmpty()
    {
        return size() == 0;
    }

    // return number of key-value pairs in BST
    public int size()
    {
        return size(root);
    }

    // return number of key-value pairs in BST rooted at x
    private int size(Node x)
    {
        if (x == null) return 0;
        else return x.N;
    }

    /***********************************************************************
     *  Search BST for given key, and return associated value if found,
     *  return null if not found
     ***********************************************************************/
    // does there exist a key-value pair with given key?
    public bool contains(Key key)
    {
        return get(key) != null;
    }

    // return value associated with the given key, or null if no such key exists
    public Value get(Key key)
    {
        return get(root, key);
    }

    private Value get(Node x, Key key)
    {
        if (x == null) return default(Value);
        int cmp = key.CompareTo(x.key);
        if (cmp < 0) return get(x.left, key);
        else if (cmp > 0) return get(x.right, key);
        else return x.val;
    }

    /***********************************************************************
     *  Insert key-value pair into BST
     *  If key already exists, update with new value
     ***********************************************************************/

    public void put(Key key, Value val)
    {
        if (val == null)
        {
            delete(key);
            return;
        }
        root = put(root, key, val);

    }

    private Node put(Node x, Key key, Value val)
    {
        if (x == null) return new Node(key, val, 1);
        int cmp = key.CompareTo(x.key);
        if (cmp < 0) x.left = put(x.left, key, val);
        else if (cmp > 0) x.right = put(x.right, key, val);
        else x.val = val;
        x.N = 1 + size(x.left) + size(x.right);
        return x;
    }

    /***********************************************************************
     *  Delete
     ***********************************************************************/

    public void deleteMin()
    {
        if (isEmpty())
            root = deleteMin(root);
    }

    private Node deleteMin(Node x)
    {
        if (x.left == null) return x.right;
        x.left = deleteMin(x.left);
        x.N = size(x.left) + size(x.right) + 1;
        return x;
    }

    public void deleteMax()
    {
        if (isEmpty())
            root = deleteMax(root);
    }

    private Node deleteMax(Node x)
    {
        if (x.right == null) return x.left;
        x.right = deleteMax(x.right);
        x.N = size(x.left) + size(x.right) + 1;
        return x;
    }

    public void delete(Key key)
    {
        root = delete(root, key);
    }

    private Node delete(Node x, Key key)
    {
        if (x == null) return null;
        int cmp = key.CompareTo(x.key);
        if (cmp < 0) x.left = delete(x.left, key);
        else if (cmp > 0) x.right = delete(x.right, key);
        else
        {
            if (x.right == null) return x.left;
            if (x.left == null) return x.right;
            Node t = x;
            x = min(t.right);
            x.right = deleteMin(t.right);
            x.left = t.left;
        }
        x.N = size(x.left) + size(x.right) + 1;
        return x;
    }


    /***********************************************************************
     *  Min, max, floor, and ceiling
     ***********************************************************************/

    public Key min()
    {
        if (isEmpty()) return default(Key);
        return min(root).key;
    }

    private Node min(Node x)
    {
        if (x.left == null) return x;
        else return min(x.left);
    }

    public Key max()
    {
        if (isEmpty()) return default(Key);
        return max(root).key;
    }

    private Node max(Node x)
    {
        if (x.right == null) return x;
        else return max(x.right);
    }

    public Key floor(Key key)
    {
        Node x = floor(root, key);
        if (x == null) return default(Key);
        else return x.key;
    }

    private Node floor(Node x, Key key)
    {
        if (x == null) return null;
        int cmp = key.CompareTo(x.key);
        if (cmp == 0) return x;
        if (cmp < 0) return floor(x.left, key);
        Node t = floor(x.right, key);
        if (t != null) return t;
        else return x;
    }

    public Key ceiling(Key key)
    {
        Node x = ceiling(root, key);
        if (x == null) return default(Key);
        else return x.key;
    }

    private Node ceiling(Node x, Key key)
    {
        if (x == null) return null;
        int cmp = key.CompareTo(x.key);
        if (cmp == 0) return x;
        if (cmp < 0)
        {
            Node t = ceiling(x.left, key);
            if (t != null) return t;
            else return x;
        }
        return ceiling(x.right, key);
    }

    /***********************************************************************
     *  Rank and selection
     ***********************************************************************/

    public Key select(int k)
    {
        if (k < 0 || k >= size()) return default(Key);
        Node x = select(root, k);
        return x.key;
    }

    // Return key of rank k. 
    private Node select(Node x, int k)
    {
        if (x == null) return null;
        int t = size(x.left);
        if (t > k) return select(x.left, k);
        else if (t < k) return select(x.right, k - t - 1);
        else return x;
    }

    public int rank(Key key)
    {
        return rank(key, root);
    }

    // Number of keys in the subtree less than key.
    private int rank(Key key, Node x)
    {
        if (x == null) return 0;
        int cmp = key.CompareTo(x.key);
        if (cmp < 0) return rank(key, x.left);
        else if (cmp > 0) return 1 + size(x.left) + rank(key, x.right);
        else return size(x.left);
    }

    /***********************************************************************
     *  Range count and range search.
     ***********************************************************************/

    public IEnumerable<Key> keys()
    {
        return keys(min(), max());
    }

    public IEnumerable<Key> keys(Key lo, Key hi)
    {
        Queue<Key> queue = new Queue<Key>();
        keys(root, queue, lo, hi);
        return queue;
    }

    private void keys(Node x, Queue<Key> queue, Key lo, Key hi)
    {
        if (x == null) return;
        int cmplo = lo.CompareTo(x.key);
        int cmphi = hi.CompareTo(x.key);
        if (cmplo < 0) keys(x.left, queue, lo, hi);
        if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(x.key);
        if (cmphi > 0) keys(x.right, queue, lo, hi);
    }

    public int size(Key lo, Key hi)
    {
        if (lo.CompareTo(hi) > 0) return 0;
        if (contains(hi)) return rank(hi) - rank(lo) + 1;
        else return rank(hi) - rank(lo);
    }


    // height of this BST (one-node tree has height 0)
    public int height()
    {
        return height(root);
    }

    private int height(Node x)
    {
        if (x == null) return -1;
        return 1 + Math.Max(height(x.left), height(x.right));
    }


    // level order traversal
    public IEnumerable<Key> levelOrder()
    {
        Queue<Key> keys = new Queue<Key>();
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            Node x = queue.Dequeue();
            if (x == null) continue;
            keys.Enqueue(x.key);
            queue.Enqueue(x.left);
            queue.Enqueue(x.right);
        }
        return keys;
    }
}

