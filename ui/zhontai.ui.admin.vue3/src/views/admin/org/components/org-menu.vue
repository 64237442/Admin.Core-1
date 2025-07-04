<template>
  <el-card shadow="never" style="margin-top: 8px" body-style="padding:0px;" class="my-fill">
    <template #header>
      <div class="my-flex">
        <el-input v-model="state.filterText" placeholder="筛选部门" clearable />
        <el-dropdown trigger="hover">
          <div class="my-flex my-flex-items-center my-icon-more">
            <my-icon name="more" color="var(--color)" size="22"></my-icon>
          </div>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item @click="expandAllNodes(true)">展开全部</el-dropdown-item>
              <el-dropdown-item @click="expandAllNodes(false)">收缩全部</el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </div>
    </template>
    <el-scrollbar v-loading="state.loading" height="100%" max-height="100%" :always="false" wrap-style="padding:10px">
      <el-tree
        ref="orgMenuRef"
        :data="state.orgTreeData"
        node-key="id"
        :props="{ children: 'children', label: 'name' }"
        :filter-node-method="onFilterNode"
        highlight-current
        check-strictly
        default-expand-all
        render-after-expand
        :expand-on-click-node="false"
        v-bind="$attrs"
        @node-click="onNodeClick"
        @check-change="onCheckChange"
      />
    </el-scrollbar>
  </el-card>
</template>

<script lang="ts" setup name="admin/org/menu">
import { onMounted, reactive, ref, watch, nextTick, PropType } from 'vue'
import { OrgGetListOutput } from '/@/api/admin/data-contracts'
import { OrgApi } from '/@/api/admin/Org'
import { listToTree } from '/@/utils/tree'
import { ElTree } from 'element-plus'

const props = defineProps({
  modelValue: {
    type: Array as PropType<number[] | undefined | null>,
    default: () => [],
  },
  selectFirstNode: {
    type: Boolean,
    default: () => false,
  },
})

const orgMenuRef = ref<InstanceType<typeof ElTree>>()
const state = reactive({
  loading: false,
  filterText: '',
  orgTreeData: [] as Array<OrgGetListOutput>,
  lastKey: 0,
})

watch(
  () => state.filterText,
  (val) => {
    orgMenuRef.value?.filter(val)
  }
)

onMounted(() => {
  initData()
})

const emits = defineEmits<{
  (e: 'node-click', node: OrgGetListOutput | null): void
  (e: 'update:modelValue', node: any[] | undefined | null): void
}>()

/**
 * 展开或收缩所有树节点
 * @param expanded 是否展开
 */
const expandAllNodes = (expanded: boolean) => {
  if (!orgMenuRef.value) return

  const treeNodes = orgMenuRef.value.store.nodesMap
  Object.values(treeNodes).forEach((node) => {
    node.expanded = expanded
  })
}

const onFilterNode = (value: string, data: OrgGetListOutput) => {
  if (!value) return true
  return data.name?.indexOf(value) !== -1
}

const onNodeClick = (node: OrgGetListOutput) => {
  if (state.lastKey === node.id) {
    state.lastKey = 0
    orgMenuRef.value?.setCurrentKey(undefined)
    emits('node-click', null)
  } else {
    state.lastKey = node.id as number
    emits('node-click', node)
  }
}

const onCheckChange = () => {
  emits('update:modelValue', orgMenuRef.value?.getCheckedKeys())
}

const initData = async () => {
  state.loading = true
  const res = await new OrgApi().getList().catch(() => {
    state.loading = false
  })
  state.loading = false
  if (res?.success && res.data && res.data.length > 0) {
    state.orgTreeData = listToTree(res.data)
    if (state.orgTreeData.length > 0 && props.selectFirstNode) {
      nextTick(() => {
        const firstNode = state.orgTreeData[0]
        orgMenuRef.value?.setCurrentKey(firstNode.id)
        onNodeClick(firstNode)
      })
    }
  } else {
    state.orgTreeData = []
  }
}

defineExpose({
  orgMenuRef,
})
</script>

<style lang="scss" scoped>
.my-icon-more {
  cursor: pointer;
  --el-button-text-color: var(--el-text-color-regular);
  --el-button-hover-text-color: var(--el-color-primary);
  color: var(--el-button-text-color);
  fill: currentColor;
  &:hover {
    color: var(--el-button-hover-text-color);
  }
}
</style>
