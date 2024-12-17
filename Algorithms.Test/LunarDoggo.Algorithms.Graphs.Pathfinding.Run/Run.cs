// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_bbc3b7dcfd
ROOST_METHOD_SIG_HASH=Run_23f9485d25

   ########## Test-Scenarios ##########  

Based on the provided method and context, here are several test scenarios for the `Run` method of the `BreadthFirstSearch` class:

Scenario 1: Null Graph Input

Details:
  TestName: ThrowsArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is provided.
Execution:
  Arrange: Create a BreadthFirstSearch instance and prepare a null graph and a valid start vertex.
  Act: Call the Run method with the null graph and valid start vertex.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input for the graph parameter, maintaining robustness and preventing null reference exceptions later in the execution.

Scenario 2: Valid Graph with Single Vertex

Details:
  TestName: ProcessesSingleVertexGraphCorrectly
  Description: Ensure the method correctly processes a graph with only one vertex (the start vertex).
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with a single vertex, and set this vertex as the start.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that the start vertex has a distance of 0 and is marked as processed.
Validation:
  This test confirms that the method correctly initializes and processes the simplest possible graph, setting the foundation for more complex scenarios.

Scenario 3: Graph with Multiple Vertices

Details:
  TestName: CorrectlyProcessesMultiVertexGraph
  Description: Verify that the method correctly processes a graph with multiple vertices, setting distances and predecessors.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple vertices and edges, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices are processed, have correct distances from the start, and have appropriate predecessors set.
Validation:
  This test ensures that the core functionality of the BFS algorithm is working correctly for a typical use case with multiple vertices and edges.

Scenario 4: Disconnected Graph

Details:
  TestName: HandlesDisconnectedGraphCorrectly
  Description: Ensure the method correctly processes a graph with disconnected components.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple disconnected components, and choose a start vertex in one component.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that vertices in the same component as the start are processed and have distances set, while vertices in other components remain unprocessed with maximum distance.
Validation:
  This test confirms that the method behaves correctly when faced with a graph that isn't fully connected, a common edge case in graph processing.

Scenario 5: Cyclic Graph

Details:
  TestName: ProcessesCyclicGraphWithoutInfiniteLoop
  Description: Verify that the method correctly handles a graph containing cycles without entering an infinite loop.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with cycles, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices are processed exactly once and have correct distances and predecessors set.
Validation:
  This test ensures that the method can handle graphs with cycles, a critical aspect of graph traversal algorithms to prevent infinite loops.

Scenario 6: Large Graph Performance

Details:
  TestName: CompletesInReasonableTimeForLargeGraph
  Description: Ensure the method completes within a reasonable time frame for a large graph.
Execution:
  Arrange: Create a BreadthFirstSearch instance, generate a large graph (e.g., 10000+ vertices), and choose a start vertex.
  Act: Measure the time taken to call and complete the Run method.
  Assert: Verify that the execution time is within an acceptable range and all vertices are processed.
Validation:
  This test checks the performance characteristics of the method, ensuring it scales well for larger inputs, which is crucial for real-world applications.

These scenarios cover various aspects of the BreadthFirstSearch.Run method, including error handling, correctness for different graph structures, and performance considerations. They aim to validate the method's behavior across a range of inputs and conditions.


*/

// ********RoostGPT********
using NUnit.Framework;
using LunarDoggo.Datastructures.Graphs;
using LunarDoggo.Algorithms.Graphs.Pathfinding;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LunarDoggo.Algorithms.Graphs.Pathfinding.Test
{
    [TestFixture]
    public class RunTest
    {
        private BreadthFirstSearch bfs;

        [SetUp]
        public void Setup()
        {
            bfs = new BreadthFirstSearch();
        }

        [Test, Category("invalid")]
        public void ThrowsArgumentNullExceptionWhenGraphIsNull()
        {
            var startVertex = new Vertex<BFSVertex>(0, new BFSVertex());
            Assert.Throws<ArgumentNullException>(() => bfs.Run(null, startVertex));
        }

        [Test, Category("valid")]
        public void ProcessesSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var startVertex = graph.AddVertex(new BFSVertex());

            bfs.Run(graph, startVertex);

            Assert.That(startVertex.Value.Distance, Is.EqualTo(0));
            Assert.That(startVertex.Value.Processed, Is.True);
        }

        [Test, Category("valid")]
        public void CorrectlyProcessesMultiVertexGraph()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            bfs.Run(graph, v1);

            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(2));
            Assert.That(v1.Value.Processed && v2.Value.Processed && v3.Value.Processed, Is.True);
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v2));
        }

        [Test, Category("valid")]
        public void HandlesDisconnectedGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);

            bfs.Run(graph, v1);

            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(int.MaxValue));
            Assert.That(v1.Value.Processed && v2.Value.Processed, Is.True);
            Assert.That(v3.Value.Processed, Is.False);
        }

        [Test, Category("valid")]
        public void ProcessesCyclicGraphWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            bfs.Run(graph, v1);

            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(1));
            Assert.That(v1.Value.Processed && v2.Value.Processed && v3.Value.Processed, Is.True);
        }

        [Test, Category("valid")]
        public void CompletesInReasonableTimeForLargeGraph()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var vertices = new List<Vertex<BFSVertex>>();
            for (int i = 0; i < 10000; i++)
            {
                vertices.Add(graph.AddVertex(new BFSVertex()));
            }

            for (int i = 0; i < 9999; i++)
            {
                graph.AddEdge(vertices[i], vertices[i + 1]);
            }

            var startTime = DateTime.Now;
            bfs.Run(graph, vertices[0]);
            var endTime = DateTime.Now;

            Assert.That((endTime - startTime).TotalSeconds, Is.LessThan(5));
            Assert.That(vertices.All(v => v.Value.Processed), Is.True);
        }
    }
}
