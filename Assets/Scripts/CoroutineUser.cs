//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CoroutineUser : MonoBehaviour
//{
//    public IEnumerator current;
//    public Queue<IEnumerator> queue;

//    public void Enqueue(IEnumerator routine)
//    {
//        queue.Enqueue(routine);
//    }

//    public void Enqueue(IEnumerable<IEnumerator> routines)
//    {
//        foreach (IEnumerator routine in routines)
//        {
//            Enqueue(routine);
//        }
//    }

//    private IEnumerator StartCurrent()
//    {
//        yield return StartCoroutine(current);
//        yield return new WaitForSeconds(1F);
//        current = null;
//    }

//    private void Update()
//    {
//        if (current == null && queue.Count > 0)
//        {
//            current = queue.Dequeue();
//            StartCoroutine(StartCurrent());
//        }
//    }
//}
