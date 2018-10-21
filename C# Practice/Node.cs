 public class Node<U> {
     public U data;
     public Node<U> next;
     // public U Data { get { return data; } }
     // public Node<U> next { get { return next; } set { next = value; } }
     public Node(U u, Node<U> next) {
         this.data = u;
         this.next = next;
     }
     public Node() {
         this.data = default(U);
         this.next = null;
     }
     public Node(U u) {
         this.data = u;
         this.next = null;
     }
     public Node(Node<U> next) {
         this.data = default(U);
         this.next = next;
     }
     // public Node(U t = default(U)) {
     //     this.t = t;
     // }

 }