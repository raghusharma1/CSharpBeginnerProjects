// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_a2e9436d0a
ROOST_METHOD_SIG_HASH=Run_9ce955ed80

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `DepthFirstSearch` class:

Scenario 1: Null Graph Handling

Details:
  TestName: ThrowArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is passed.
Execution:
  Arrange: Create a DepthFirstSearch instance.
  Act: Call the Run method with a null graph.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input, preventing null reference exceptions later in the execution.

Scenario 2: Empty Graph Processing

Details:
  TestName: ProcessEmptyGraphWithoutException
  Description: Ensure that the method can process an empty graph without throwing exceptions.
Execution:
  Arrange: Create a DepthFirstSearch instance and an empty IGraph<DFSVertex>.
  Act: Call the Run method with the empty graph.
  Assert: Verify that no exception is thrown and the method completes successfully.
Validation:
  This test confirms that the method can handle edge cases like empty graphs without errors.

Scenario 3: Single Vertex Graph Processing

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Check if the method correctly processes a graph with a single vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with one vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Verify that the vertex's StartTime and EndTime are set and Processed is true.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Multiple Disconnected Vertices Processing

Details:
  TestName: ProcessMultipleDisconnectedVerticesCorrectly
  Description: Verify that the method correctly processes a graph with multiple disconnected vertices.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple disconnected vertices.
  Act: Call the Run method with the graph.
  Assert: Check that all vertices have been processed (Processed is true, StartTime and EndTime are set).
Validation:
  This test ensures that the method can handle graphs with multiple components.

Scenario 5: Connected Graph Processing

Details:
  TestName: ProcessConnectedGraphCorrectly
  Description: Ensure that the method correctly processes a connected graph, visiting all vertices.
Execution:
  Arrange: Create a DepthFirstSearch instance and a connected IGraph<DFSVertex>.
  Act: Call the Run method with the graph.
  Assert: Verify that all vertices are processed and have correct StartTime and EndTime values.
Validation:
  This test checks the core functionality of the depth-first search algorithm on a typical connected graph.

Scenario 6: Cyclic Graph Processing

Details:
  TestName: ProcessCyclicGraphWithoutInfiniteLoop
  Description: Check if the method can process a graph containing cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with cycles.
  Act: Call the Run method with the cyclic graph.
  Assert: Verify that all vertices are processed and the method completes in a reasonable time.
Validation:
  This test ensures that the algorithm can handle graphs with cycles, which is crucial for its robustness.

Scenario 7: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Verify that the method can process a large graph within a reasonable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> (e.g., 10000 vertices).
  Act: Call the Run method with the large graph and measure execution time.
  Assert: Check that all vertices are processed and the execution time is within an acceptable range.
Validation:
  This test ensures that the algorithm's performance scales well with larger graphs.

Scenario 8: Predecessor Assignment Correctness

Details:
  TestName: AssignPredecessorsCorrectlyInConnectedGraph
  Description: Ensure that the method correctly assigns predecessors to vertices in a connected graph.
Execution:
  Arrange: Create a DepthFirstSearch instance and a connected IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that each vertex (except the start vertex) has a correct predecessor assigned.
Validation:
  This test checks if the depth-first search correctly builds the search tree by assigning predecessors.

These test scenarios cover various aspects of the `Run` method, including error handling, edge cases, and core functionality across different types of graphs.


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
    public class Run188Test
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

        [Test, Category("valid")]
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
        public void ProcessMultipleDisconnectedVerticesCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex1 = graph.AddVertex(new DFSVertex());
            var vertex2 = graph.AddVertex(new DFSVertex());
            var vertex3 = graph.AddVertex(new DFSVertex());

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessConnectedGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex1 = graph.AddVertex(new DFSVertex());
            var vertex2 = graph.AddVertex(new DFSVertex());
            var vertex3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessCyclicGraphWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex1 = graph.AddVertex(new DFSVertex());
            var vertex2 = graph.AddVertex(new DFSVertex());
            var vertex3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);

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

            var startTime = DateTime.Now;
            dfs.Run(graph);
            var duration = DateTime.Now - startTime;

            Assert.That(duration.TotalSeconds, Is.LessThan(5));
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void AssignPredecessorsCorrectlyInConnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex1 = graph.AddVertex(new DFSVertex());
            var vertex2 = graph.AddVertex(new DFSVertex());
            var vertex3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            dfs.Run(graph);

            Assert.That(vertex1.Value.Predecessor, Is.Null);
            Assert.That(vertex2.Value.Predecessor, Is.EqualTo(vertex1).Or.EqualTo(vertex3));
            Assert.That(vertex3.Value.Predecessor, Is.EqualTo(vertex2).Or.EqualTo(vertex1));
        }
    }
}
