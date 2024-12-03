// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type Claude AI and AI Model claude-3-5-sonnet-20240620

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

Scenario 4: Connected Graph Processing

Details:
  TestName: ProcessConnectedGraphCorrectly
  Description: Verify that all vertices in a connected graph are processed in the correct order.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple connected vertices.
  Act: Call the Run method with the connected graph.
  Assert: Check that all vertices are processed, have valid StartTime and EndTime, and form a valid DFS tree.
Validation:
  This test confirms that the method correctly traverses a connected graph, setting appropriate values for each vertex.

Scenario 5: Disconnected Graph Processing

Details:
  TestName: ProcessDisconnectedGraphCorrectly
  Description: Ensure that all components of a disconnected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple disconnected components.
  Act: Call the Run method with the disconnected graph.
  Assert: Verify that all vertices in all components are processed and have valid StartTime and EndTime values.
Validation:
  This test checks if the method can handle graphs with multiple disconnected components, ensuring complete traversal.

Scenario 6: Cyclic Graph Processing

Details:
  TestName: ProcessCyclicGraphWithoutInfiniteLoop
  Description: Check if the method can process a graph containing cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with cycles.
  Act: Call the Run method with the cyclic graph.
  Assert: Confirm that all vertices are processed exactly once and have valid StartTime and EndTime values.
Validation:
  This test ensures that the method can handle graphs with cycles, a common scenario in real-world applications.

Scenario 7: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Verify that the method can process a large graph within an acceptable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> with many vertices and edges.
  Act: Call the Run method with the large graph, measuring execution time.
  Assert: Check that all vertices are processed and the execution time is within an acceptable limit.
Validation:
  This test assesses the performance characteristics of the method for large inputs, ensuring scalability.

Scenario 8: Predecessor Assignment Correctness

Details:
  TestName: AssignPredecessorsCorrectlyDuringTraversal
  Description: Ensure that the Predecessor property of each vertex is set correctly during the traversal.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that each vertex's Predecessor matches the expected DFS tree structure.
Validation:
  This test confirms that the method correctly builds the DFS tree by setting appropriate predecessors.

These test scenarios cover various aspects of the `Run` method, including edge cases, error handling, and different graph structures. They aim to ensure the correctness and robustness of the Depth-First Search implementation.


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
    public class Run235Test
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
        public void ProcessCyclicGraphWithoutInfiniteLoop()
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
        public void ProcessLargeGraphWithinReasonableTime()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            for (int i = 0; i < 10000; i++)
            {
                graph.AddVertex(new DFSVertex());
            }

            // TODO: Add more edges to make the graph more complex if needed

            var startTime = DateTime.Now;
            dfs.Run(graph);
            var endTime = DateTime.Now;

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That((endTime - startTime).TotalSeconds, Is.LessThan(5)); // Adjust the time limit as needed
        }

        [Test, Category("valid")]
        public void AssignPredecessorsCorrectlyDuringTraversal()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            dfs.Run(graph);

            Assert.That(v1.Value.Predecessor, Is.Null);
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v2));
        }

        [TearDown]
        public void TearDown()
        {
            dfs = null;
        }
    }
}
