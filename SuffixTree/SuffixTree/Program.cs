using System;

class SuffixNode : IComparable<SuffixNode>
{
    public string Suffix { get; set; }
    public int Index { get; set; }

    public int CompareTo(SuffixNode node)
    {
        return Suffix.CompareTo(node.Suffix);
    }
}

class A
{

    public static void Main(string[] args)
    {
        string str = "thisisagreatstory";
        int[] sa = new int[6];

        var p = new A();
        p.BuildSA(str, sa);
        foreach (var i in sa) { Console.Write(i + " "); }
        string pat = "isag";
        p.Search(sa, pat, str);
        Console.Read();
    }

    private void Search(int [] sa, string pat, string text)
    {
        int l = 0; int r = sa.Length - 1;
        while(l<=r)
        {
            int mid = l + (r - l) / 2;
            var result = string.Compare(pat, 0, text.Substring(sa[mid]), 0, pat.Length);
            if (result == 0)
            {
                Console.WriteLine("Pattern found at " + sa[mid]);
                return;
            }
            if (result < 0) r = mid - 1;
            if (result > 0) l = mid + 1;
        }
        
    }

    private void BuildSA(string str, int[] sa)
    {
        SuffixNode[] nodes = new SuffixNode[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            nodes[i] = new SuffixNode
            {
                Suffix = str.Substring(i),
                Index = i
            };
        }
        Array.Sort(nodes);
        for (int i = 0; i < sa.Length; i++)
        {
            sa[i] = nodes[i].Index;
        }
    }

    
}
