namespace IT_Task1.Classes;

public class MyQueue<T>
{
    private int _count;
    private QueueNode<T>? head;

    public MyQueue()
    {
        this._count = 0;
        this.head = null;
    }

    public int Count
    {
        get { return _count; }
    }

    public bool IsEmpty
    {
        get { return this.Count == 0; }
    }

    public T Current
    {
        get
        {
            if (head != null)
            {
                return head.Item;
            }
            else
                throw new EmptyQueueException();
        }
    }

    public T Dequeue()
    {
        if (head != null)
        {
            T res = head.Item;
            head = head.Next;
            _count--;
            return res;
        }
        else
        {
            throw new EmptyQueueException();
        }
    }

    public void Inqueue(T item)
    {
        QueueNode<T> node = new(item);
        if (head == null)
        {
            head = node;
        }
        else
        {
            QueueNode<T> tail = head;
            while (tail.Next != null)
            {
                tail = tail.Next;
            }

            tail.Next = node;
        }

        _count++;
    }

    public void Clear()
    {
        while (!IsEmpty)
        {
            Dequeue();
        }
    }
    
    private class QueueNode<T>
    {
        public QueueNode(T item)
        {
            this.Item = item;
            this.Next = null;
        }
    
        public T Item { get; }
    
        public QueueNode<T>? Next { get; set; }
    }
}

