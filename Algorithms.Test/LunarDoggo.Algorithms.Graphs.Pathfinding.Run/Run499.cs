// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_a2e9436d0a
ROOST_METHOD_SIG_HASH=Run_9ce955ed80

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `DepthFirstSearch` class:

Scenario 1: Null Graph Handling

Details:
  TestName: ThrowsArgumentNullExceptionForNullGraph
  Description: Verify that the method throws an ArgumentNullException when a null graph is passed.
Execution:
  Arrange: Create a DepthFirstSearch instance.
  Act: Call the Run method with a null graph.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input, preventing null reference exceptions later in the execution.

Scenario 2: Empty Graph Processing

Details:
  TestName: ProcessesEmptyGraphWithoutErrors
  Description: Ensure the method can handle an empty graph without throwing exceptions.
Execution:
  Arrange: Create a DepthFirstSearch instance and an empty IGraph<DFSVertex>.
  Act: Call the Run method with the empty graph.
  Assert: Verify that no exception is thrown and the method completes successfully.
Validation:
  This test confirms that the method can handle edge cases like empty graphs gracefully.

Scenario 3: Single Vertex Graph Processing

Details:
  TestName: ProcessesSingleVertexGraphCorrectly
  Description: Check if the method correctly processes a graph with a single vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with one vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Verify that the vertex's StartTime and EndTime are set and Processed is true.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Connected Graph Processing

Details:
  TestName: ProcessesConnectedGraphCorrectly
  Description: Verify that all vertices in a connected graph are processed in the correct order.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple connected vertices.
  Act: Call the Run method with the connected graph.
  Assert: Check that all vertices are processed, have valid StartTime and EndTime, and form a valid DFS tree.
Validation:
  This test confirms that the DFS algorithm works correctly for a typical connected graph scenario.

Scenario 5: Disconnected Graph Processing

Details:
  TestName: ProcessesDisconnectedGraphCorrectly
  Description: Ensure that all components of a disconnected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple disconnected components.
  Act: Call the Run method with the disconnected graph.
  Assert: Verify that all vertices in all components are processed and have valid times.
Validation:
  This test checks if the method correctly handles graphs with multiple disconnected components.

Scenario 6: Cyclic Graph Processing

Details:
  TestName: ProcessesCyclicGraphWithoutInfiniteLoop
  Description: Check if the method can process a graph containing cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with cycles.
  Act: Call the Run method with the cyclic graph.
  Assert: Verify that all vertices are processed and the method terminates.
Validation:
  This test ensures that the DFS algorithm can handle graphs with cycles, which is crucial for its correctness.

Scenario 7: Large Graph Performance

Details:
  TestName: ProcessesLargeGraphInReasonableTime
  Description: Verify that the method can process a large graph within an acceptable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> with many vertices and edges.
  Act: Call the Run method with the large graph, measuring execution time.
  Assert: Check that all vertices are processed and the execution time is within an acceptable limit.
Validation:
  This test assesses the performance characteristics of the DFS implementation for large inputs.

Scenario 8: Predecessor Assignment Correctness

Details:
  TestName: AssignsPredecessorsCorrectly
  Description: Ensure that the Predecessor property of each vertex is set correctly during the DFS.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that each vertex's Predecessor forms a valid DFS tree.
Validation:
  This test checks if the DFS algorithm correctly builds the DFS tree through proper predecessor assignments.

These test scenarios cover various aspects of the DepthFirstSearch.Run method, including error handling, edge cases, correctness for different graph types, and performance considerations.


*/

// ********RoostGPT********
using NUnit.Framework;
using LunarDoggo.Datastructures.Graphs;
using LunarDoggo.Algorithms.Graphs.Pathfinding;
using System;
using System.Linq;

namespace LunarDoggo.Algorithms.Graphs.Pathfinding.Test
{
    [TestFixture]
    public class Run499Test
    {
        private DepthFirstSearch dfs;

        [SetUp]
        public void Setup()
        {
            dfs = new DepthFirstSearch();
        }

        [Test, Category("invalid")]
        public void ThrowsArgumentNullExceptionForNullGraph()
        {
            Assert.Throws<ArgumentNullException>(() => dfs.Run(null));
        }

        [Test, Category("valid")]
        public void ProcessesEmptyGraphWithoutErrors()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            Assert.DoesNotThrow(() => dfs.Run(graph));
        }

        [Test, Category("valid")]
        public void ProcessesSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex = graph.AddVertex(new DFSVertex());

            dfs.Run(graph);

            Assert.That(vertex.Value.Processed, Is.True);
            Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
            Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
        }

        [Test, Category("valid")]
        public void ProcessesConnectedGraphCorrectly()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            foreach (var vertex in graph.Vertices)
            {
                Assert.That(vertex.Value.Processed, Is.True);
                Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
                Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
            }

            Assert.That(IsValidDFSTree(graph), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessesDisconnectedGraphCorrectly()
        {
            var graph = CreateDisconnectedGraph();

            dfs.Run(graph);

            foreach (var vertex in graph.Vertices)
            {
                Assert.That(vertex.Value.Processed, Is.True);
                Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
                Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
            }
        }

        [Test, Category("valid")]
        public void ProcessesCyclicGraphWithoutInfiniteLoop()
        {
            var graph = CreateCyclicGraph();

            dfs.Run(graph);

            foreach (var vertex in graph.Vertices)
            {
                Assert.That(vertex.Value.Processed, Is.True);
                Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
                Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
            }
        }

        [Test, Category("valid")]
        public void ProcessesLargeGraphInReasonableTime()
        {
            var graph = CreateLargeGraph(1000);

            var startTime = DateTime.Now;
            dfs.Run(graph);
            var endTime = DateTime.Now;

            var executionTime = (endTime - startTime).TotalSeconds;
            Assert.That(executionTime, Is.LessThan(5)); // Adjust the time limit as needed

            foreach (var vertex in graph.Vertices)
            {
                Assert.That(vertex.Value.Processed, Is.True);
            }
        }

        [Test, Category("valid")]
        public void AssignsPredecessorsCorrectly()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            Assert.That(IsValidDFSTree(graph), Is.True);
        }

        private bool IsValidDFSTree(IGraph<DFSVertex> graph)
        {
            var root = graph.Vertices.FirstOrDefault(v => v.Value.Predecessor == null);
            if (root == null) return false;

            foreach (var vertex in graph.Vertices.Where(v => v != root))
            {
                if (vertex.Value.Predecessor == null) return false;
                if (vertex.Value.StartTime <= vertex.Value.Predecessor.Value.StartTime) return false;
                if (vertex.Value.EndTime >= vertex.Value.Predecessor.Value.EndTime) return false;
            }

            return true;
        }

        private IGraph<DFSVertex> CreateConnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            return graph;
        }

        private IGraph<DFSVertex> CreateDisconnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            return graph;
        }

        private IGraph<DFSVertex> CreateCyclicGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);
            return graph;
        }

        private IGraph<DFSVertex> CreateLargeGraph(int size)
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertices = Enumerable.Range(0, size).Select(_ => graph.AddVertex(new DFSVertex())).ToList();

            for (int i = 1; i < size; i++)
            {
                graph.AddEdge(vertices[i - 1], vertices[i]);
            }

            return graph;
        }
    }
}
