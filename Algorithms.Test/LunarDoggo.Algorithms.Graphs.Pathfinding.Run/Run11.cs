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
  Assert: Confirm that all vertices are processed and the method terminates.
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

Scenario 8: Predecessor Chain Correctness

Details:
  TestName: SetsPredecessorChainCorrectly
  Description: Ensure that the predecessor chain in the resulting DFS tree is correct.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that the predecessor chain for each vertex forms a valid path back to a root vertex.
Validation:
  This test confirms that the DFS algorithm correctly sets up the tree structure through predecessor relationships.

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
    public class Run11Test
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
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessesDisconnectedGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            var v4 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v4);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessesCyclicGraphWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessesLargeGraphInReasonableTime()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            for (int i = 0; i < 10000; i++)
            {
                graph.AddVertex(new DFSVertex());
            }

            for (int i = 0; i < 9999; i++)
            {
                graph.AddEdge(graph.Vertices.ElementAt(i), graph.Vertices.ElementAt(i + 1));
            }

            Assert.That(() => dfs.Run(graph), Throws.Nothing.And.CompletesBefore(TimeSpan.FromSeconds(5)));
        }

        [Test, Category("valid")]
        public void SetsPredecessorChainCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            var v4 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v4);

            dfs.Run(graph);

            Assert.That(v4.Value.Predecessor, Is.EqualTo(v3));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v2));
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v1.Value.Predecessor, Is.Null);
        }
    }
}
