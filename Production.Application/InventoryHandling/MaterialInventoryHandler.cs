namespace Production.Application.InventoryHandling
{
    public interface IMaterialInventoryHandler
    {
        MaterialInformationDto GetMaterialInformation(int productionTime, Domain.Entities.Material material);
        void AddMaterialDemand(Domain.Entities.Material material, MaterialInformationDto informationDto);
        void RemoveMaterialDemand(Domain.Entities.Material material, MaterialInformationDto informationDto);
    }

    public class MaterialInventoryHandler : IMaterialInventoryHandler
    {
        public MaterialInformationDto GetMaterialInformation(int productionTime, Domain.Entities.Material material)
        {
            var consumption = material.InjectionMold!.Consumption;

            if (material == null || consumption <= 0 || productionTime <= 1)
            {
                throw new ArgumentException();
            }

            return new MaterialInformationDto(productionTime, consumption);
        }

        public void AddMaterialDemand(Domain.Entities.Material material, MaterialInformationDto informationDto)
        {
            material.Stock.PlannedMaterialDemand += informationDto.Usage;

            material.Stock.CountMaterialToOrder();
        }

        public void RemoveMaterialDemand(Domain.Entities.Material material, MaterialInformationDto informationDto)
        {
            if (material.Stock.PlannedMaterialDemand < informationDto.Usage)
            {
                throw new ArgumentException();
            }
            material.Stock.PlannedMaterialDemand -= informationDto.Usage;

            material.Stock.CountMaterialToOrder();
        }
    }
}
