// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_a2e9436d0a
ROOST_METHOD_SIG_HASH=Run_9ce955ed80

   ########## Test-Scenarios ##########  

Based on the provided method and context, here are several test scenarios for the `Run` method of the `DepthFirstSearch` class:

Scenario 1: Null Graph Input

Details:
  TestName: ThrowArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is passed as an argument.
Execution:
  Arrange: Create a DepthFirstSearch instance.
  Act: Call the Run method with a null graph.
  Assert: Verify that an ArgumentNullException is thrown with the correct message.
Validation:
  This test ensures that the method properly handles null input, preventing potential null reference exceptions later in the execution.

Scenario 2: Empty Graph

Details:
  TestName: ProcessEmptyGraphWithoutException
  Description: Ensure that the method can handle an empty graph (a graph with no vertices) without throwing an exception.
Execution:
  Arrange: Create a DepthFirstSearch instance and an empty IGraph<DFSVertex>.
  Act: Call the Run method with the empty graph.
  Assert: Verify that the method completes without throwing an exception.
Validation:
  This test confirms that the method can handle edge cases like empty graphs gracefully.

Scenario 3: Single Vertex Graph

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Verify that the method correctly processes a graph with a single vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with one vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Check that the vertex's StartTime and EndTime are set and Processed is true.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Connected Graph

Details:
  TestName: ProcessConnectedGraphCorrectly
  Description: Verify that the method correctly processes a connected graph with multiple vertices.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple connected vertices.
  Act: Call the Run method with the connected graph.
  Assert: Verify that all vertices are processed, have valid StartTime and EndTime values, and form a valid DFS tree structure.
Validation:
  This test checks the core functionality of the DFS algorithm on a typical connected graph.

Scenario 5: Disconnected Graph

Details:
  TestName: ProcessDisconnectedGraphCorrectly
  Description: Ensure that the method correctly handles a disconnected graph with multiple components.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple disconnected components.
  Act: Call the Run method with the disconnected graph.
  Assert: Verify that all vertices in all components are processed and have valid StartTime and EndTime values.
Validation:
  This test confirms that the method can handle graphs with multiple disconnected components, ensuring complete traversal.

Scenario 6: Graph with Cycles

Details:
  TestName: HandleGraphWithCyclesWithoutInfiniteLoop
  Description: Verify that the method correctly processes a graph containing cycles without entering an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with cycles.
  Act: Call the Run method with the cyclic graph.
  Assert: Check that all vertices are processed, have valid StartTime and EndTime values, and the method terminates.
Validation:
  This test ensures that the DFS algorithm can handle graphs with cycles, which is crucial for its correctness and termination.

Scenario 7: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Ensure that the method can process a large graph within a reasonable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> with many vertices and edges.
  Act: Call the Run method with the large graph and measure the execution time.
  Assert: Verify that the method completes within a specified time limit and all vertices are processed.
Validation:
  This test checks the performance characteristics of the DFS implementation, ensuring it scales well with larger inputs.

These test scenarios cover various aspects of the `Run` method, including edge cases, typical use cases, and performance considerations. They aim to ensure the correctness, robustness, and efficiency of the Depth-First Search implementation.


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
    public class Run587Test
    {
        private DepthFirstSearch dfs;

        [SetUp]
        public void Setup()
        {
            dfs = new DepthFirstSearch();
        }

        [Test, Category("invalid")]
        public void ThrowArgumentNullExceptionWhenGraphIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => dfs.Run(null));
        }

        [Test, Category("boundary")]
        public void ProcessEmptyGraphWithoutException()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            Assert.DoesNotThrow(() => dfs.Run(graph));
        }

        [Test, Category("valid")]
        public void ProcessSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex = graph.AddVertex(new DFSVertex());

            dfs.Run(graph);

            Assert.That(vertex.Value.Processed, Is.True);
            Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
            Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
        }

        [Test, Category("valid")]
        public void ProcessConnectedGraphCorrectly()
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
        public void ProcessDisconnectedGraphCorrectly()
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
        public void HandleGraphWithCyclesWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            Assert.DoesNotThrow(() => dfs.Run(graph));
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessLargeGraphWithinReasonableTime()
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
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }
    }
}
