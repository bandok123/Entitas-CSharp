namespace Entitas {
    public partial class Entity {
        public HealthComponent health { get { return (HealthComponent)GetComponent(ComponentIds.Health); } }

        public bool hasHealth { get { return HasComponent(ComponentIds.Health); } }

        public Entity AddHealth(int newValue) {
            var componentPool = GetComponentPool(ComponentIds.Health);
            var component = (HealthComponent)(componentPool.Count > 0 ? componentPool.Pop() : new HealthComponent());
            component.value = newValue;
            return AddComponent(ComponentIds.Health, component);
        }

        public Entity ReplaceHealth(int newValue) {
            var componentPool = GetComponentPool(ComponentIds.Health);
            var component = (HealthComponent)(componentPool.Count > 0 ? componentPool.Pop() : new HealthComponent());
            component.value = newValue;
            ReplaceComponent(ComponentIds.Health, component);
            return this;
        }

        public Entity RemoveHealth() {
            return RemoveComponent(ComponentIds.Health);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherHealth;

        public static IMatcher Health {
            get {
                if (_matcherHealth == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Health);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherHealth = matcher;
                }

                return _matcherHealth;
            }
        }
    }
}
