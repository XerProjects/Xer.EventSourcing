﻿using System;
using System.Threading.Tasks;
using Xer.EventSourcing.Repositories;
using Xer.EventSourcing.Tests.Mocks;
using Xer.EventSourcing.Tests.Utilities;
using Xunit;

namespace Xer.EventSourcing.Tests
{
    public class EventSourcedAggregateRepositoryTests
    {
        public class SaveMethod
        {
            [Fact]
            public void Should_Persist_Aggregate()
            {
                IEventSourcedAggregateRepository<TestAggregate, Guid> repository = Factory.CreateTestAggregateRepository();

                TestAggregate aggregate = new TestAggregate(Guid.NewGuid());
                repository.Save(aggregate);

                TestAggregate fromRepo = repository.GetById(aggregate.Id);

                Assert.NotNull(fromRepo);
                Assert.Equal(aggregate.Id, fromRepo.Id);
            }
        }

        public class SaveAsyncMethod
        {
            [Fact]
            public async Task Should_Persist_Aggregate()
            {
                IEventSourcedAggregateAsyncRepository<TestAggregate, Guid> repository = Factory.CreateTestAggregateAsyncRepository();

                TestAggregate aggregate = new TestAggregate(Guid.NewGuid());
                await repository.SaveAsync(aggregate);

                TestAggregate fromRepo = await repository.GetByIdAsync(aggregate.Id);

                Assert.NotNull(fromRepo);
                Assert.Equal(aggregate.Id, fromRepo.Id);
            }
        }

        public class GetByIdMethod
        {
            [Fact]
            public void Should_Retrieve_Aggregate()
            {
                IEventSourcedAggregateRepository<TestAggregate, Guid> repository = Factory.CreateTestAggregateRepository();

                TestAggregate aggregate = new TestAggregate(Guid.NewGuid());
                repository.Save(aggregate);

                TestAggregate fromRepo = repository.GetById(aggregate.Id);

                Assert.NotNull(fromRepo);
                Assert.Equal(aggregate.Id, fromRepo.Id);
            }
        }

        public class GetByIdAsyncMethod
        {
            [Fact]
            public async Task Should_Retrieve_Aggregate()
            {
                IEventSourcedAggregateAsyncRepository<TestAggregate, Guid> repository = Factory.CreateTestAggregateAsyncRepository();

                TestAggregate aggregate = new TestAggregate(Guid.NewGuid());
                await repository.SaveAsync(aggregate);

                TestAggregate fromRepo = await repository.GetByIdAsync(aggregate.Id);

                Assert.NotNull(fromRepo);
                Assert.Equal(aggregate.Id, fromRepo.Id);
            }
        }
    }
}
